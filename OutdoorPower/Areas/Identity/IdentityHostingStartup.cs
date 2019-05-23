using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutdoorPower.Models;

[assembly: HostingStartup(typeof(OutdoorPower.Areas.Identity.IdentityHostingStartup))]
namespace OutdoorPower.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<DealerEmployeeLoginCredential>()
                    .AddEntityFrameworkStores<OutdoorPowerContext>();
            });
        }
    }
}