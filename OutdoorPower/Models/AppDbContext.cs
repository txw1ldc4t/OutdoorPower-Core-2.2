using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class OutdoorPowerContext: IdentityDbContext<DealerEmployeeLoginCredential>
    {
        public OutdoorPowerContext(DbContextOptions<OutdoorPowerContext> options): base (options){

        }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<DealerEmployee> DealerEmployees { get; set; }
        public DbSet<DealerEmployeeLoginCredential> DealerEmployeeLoginCredentials { get; set; }
        public DbSet<DealerInventory> DealerInventories { get; set; }
        public DbSet<DealerInventoryImage> DealerInventoryImages { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<QInventoryMake> QInventoryMakes { get; set; }
        public DbSet<QInventoryModel> QInventoryModels { get; set; }
        public DbSet<QInventoryModelOption> QInventoryModelOptions { get; set; }
        public DbSet<QInventoryType> QInventoryTypes { get; set; }

    }
}
