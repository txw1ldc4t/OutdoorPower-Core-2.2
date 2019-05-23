using Microsoft.EntityFrameworkCore;
using OutdoorPower.Models.Metrics;

namespace OutdoorPower.Models.Metrics
{
    public class MetricsContext : DbContext
    {
        public MetricsContext(DbContextOptions<MetricsContext> options): base (options){

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<DealerMetric> DealerMetrics { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        // Needed for Stored Procedure Call, but Not Used as a Table
        public DbSet<YearlyMetric> YearlyMetrics { get; set; }

        // Needed for Stored Procedure Call, but Not Used as a Table
        public DbSet<MonthlyMetric> MonthlyMetrics { get; set; }

        public DbSet<UnitsSold> UnitsSoldSet { get; set; }

        public DbSet<DailyRevenue> DailyRevenues { get; set; }

        public DbSet<MonthlyRevenue> MonthlyRevenues { get; set; }
    }
}
