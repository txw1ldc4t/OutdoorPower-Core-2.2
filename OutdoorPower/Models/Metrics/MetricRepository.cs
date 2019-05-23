
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OutdoorPower.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models.Metrics
{
    public class MetricRepository : IMetricRepository
    {
        private readonly MetricsContext _metricsContext;
        private readonly ILogger<MetricRepository> _logger;

        public MetricRepository(
            MetricsContext metricsContext,
            ILogger<MetricRepository> logger
            )
        {
            _metricsContext = metricsContext;
            _logger = logger;
        }

        public void AddCustomer(Customer customer)
        {
            _metricsContext.Add(customer);
        }

        public List<Customer> GetCustomers(IEnumerable<int> inventoryIds)
        {
            return (from customer in _metricsContext.Customers
                    where inventoryIds.Contains(customer.OPInventoryId)
                    select customer).ToList();
        }

        public Inventory GetInventoryByOPInventoryId(int opInventoryId)
        {
            return _metricsContext.Inventories.Where(c => c.OPInventoryId == opInventoryId).FirstOrDefault();
        }

        public List<MonthlyMetric> GetMonthToDateMetrics(int dealerId)
        {
            SqlParameter dealerIdParameter = new SqlParameter
            {
                ParameterName = "@DEALERID",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = dealerId
            };

            string query = "SP_MONTHTODATE @DEALERID";
            return _metricsContext.MonthlyMetrics.FromSql(query, dealerIdParameter).ToList();
        }

        public List<DailyRevenue> GetMonthlyRevenue(int dealerId)
        {
            SqlParameter dealerIdParameter = new SqlParameter
            {
                ParameterName = "@DEALERID",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = dealerId
            };

            string query = "SP_MONTHTODATE_REVENUE @DEALERID";
            return _metricsContext.DailyRevenues.FromSql(query, dealerIdParameter).ToList();
        }

        public List<SalesInfoModalViewModel> GetSalesInfo(IEnumerable<int> inventoryIds)
        {
            return (from inventory in _metricsContext.Inventories
                    where inventoryIds.Contains(inventory.OPInventoryId)
                    select new SalesInfoModalViewModel()
                    {
                        Id = inventory.OPInventoryId,
                        PriceSold = inventory.PriceSold,
                        DateSold = inventory.DateSold,
                        DealerEmployeeId = inventory.DealerEmployeeId,
                        SalesType = inventory.SalesType
                    }).ToList();
        }

        public List<MonthlyRevenue> GetYearlyRevenue(int dealerId)
        {
            SqlParameter dealerIdParameter = new SqlParameter
            {
                ParameterName = "@DEALERID",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = dealerId
            };

            string query = "SP_YEARTODATE_REVENUE @DEALERID";
            return _metricsContext.MonthlyRevenues.FromSql(query, dealerIdParameter).ToList();
        }

        public List<UnitsSold> GetUnitsSoldMetrics(int dealerId)
        {
            SqlParameter dealerIdParameter = new SqlParameter
            {
                ParameterName = "@DEALERID",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = dealerId
            };

            string query = "SP_YEARTODATE_VOLUME @DEALERID";
            return _metricsContext.UnitsSoldSet.FromSql(query, dealerIdParameter).ToList();
        }

        public List<YearlyMetric> GetYearToDateMetrics(int dealerId)
        {
            SqlParameter dealerIdParameter = new SqlParameter
            {
                ParameterName = "@DEALERID",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = dealerId
            };

            string query = "SP_YEARTODATE @DEALERID";
            return _metricsContext.YearlyMetrics.FromSql(query, dealerIdParameter).ToList();
        }

        public async Task<bool> IsInventoryPresent(int inventoryId)
        {
            try
            {
                var sqlParams = new[]{
                new SqlParameter
                {
                    ParameterName = "@INVENTORYID",
                    SqlDbType = SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = inventoryId
                },
                new SqlParameter
                {
                    ParameterName = "@FOUND",
                    SqlDbType = SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output
                }
            };

                await _metricsContext.Database.ExecuteSqlCommandAsync("SP_PORTMETRICINVENTORY @INVENTORYID, @FOUND OUT", sqlParams);

                return ((int)sqlParams[1].Value > 0);
            } 
            catch (Exception ex)
            {
                _logger.LogError($"Failed to find inventory: (Inventory Id: {inventoryId};  Exception: {ex.Message}");
            }

            return false;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _metricsContext.SaveChangesAsync()) > 0;
        }

        public async Task<Inventory> UpdateSalesInfo(Inventory inventory)
        {
            bool found = await IsInventoryPresent(inventory.OPInventoryId);

            if (!found)
            {
                return null;
            }

            Inventory origInventory = GetInventoryByOPInventoryId(inventory.OPInventoryId);

            origInventory.DealerEmployeeId = inventory.DealerEmployeeId;
            origInventory.DateSold = inventory.DateSold;
            origInventory.PriceSold = inventory.PriceSold;
            origInventory.SalesType = inventory.SalesType;

            return origInventory;
        }
    }
}
