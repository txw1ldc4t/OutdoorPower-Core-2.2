using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutdoorPower.Models;
using OutdoorPower.Models.Metrics;
using OutdoorPower.ViewModels;

namespace OutdoorPower
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OutdoorPowerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<MetricsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MetricsConnection")));

            services.AddTransient<IOutdoorPowerRepository, OutdoorPowerRepository>();
            services.AddTransient<IMetricRepository, MetricRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "edit.users",
                    policy => policy.RequireClaim(
                        "EditAccess",
                        "DealerOwner"
                    )
                );
                options.AddPolicy(
                    "edit.inventory",
                    policy => policy.RequireClaim(
                        "EditAccess",
                        "DealerOwner"
                    )
                );
                options.AddPolicy("EditInventory", policy => policy.RequireClaim("Role", "EditInventory", "PowerUser", "DealerOwner", "Administrator"));
            });

            //register framework services
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Mapper.Initialize(config =>
            {
                config.CreateMap<QInventoryType, SelectListItem>()
                    .ForMember(dest => dest.Text,
                        opts => opts.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Value,
                        opts => opts.MapFrom(src => src.Id));
                config.CreateMap<ManageAddInventoryViewModel, DealerInventory>()
                .ForMember(x => x.Images, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Images, opt => opt.Ignore());
                config.CreateMap<SalesInfoViewModel, OutdoorPower.Models.Metrics.Inventory>();
                config.CreateMap<SalesInfoViewModel, Customer>();
                config.CreateMap<ManageAddInventoryViewModel, Models.Metrics.Inventory>();
            });

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            }
            );
        }
    }
}
