using OutdoorPower.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models.Metrics
{
    public interface IMetricRepository
    {
        void AddCustomer(Customer customer);

        List<Customer> GetCustomers(IEnumerable<int> inventoryIds);

        Inventory GetInventoryByOPInventoryId(int opInventoryId);

        List<MonthlyMetric> GetMonthToDateMetrics(int dealerId);

        List<DailyRevenue> GetMonthlyRevenue(int dealerId);

        List<SalesInfoModalViewModel> GetSalesInfo(IEnumerable<int> inventoryIds);

        List<UnitsSold> GetUnitsSoldMetrics(int dealerId);

        List<YearlyMetric> GetYearToDateMetrics(int dealerId);

        List<MonthlyRevenue> GetYearlyRevenue(int dealerId);

        Task<bool> SaveChangesAsync();

        Task<Inventory> UpdateSalesInfo(Inventory inventory);
    }
}
