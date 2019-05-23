using OutdoorPower.Models;
using OutdoorPower.Models.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.ViewModels
{
    public class ManageIndexViewModel : SearchViewModel
    {
        public ManageIndexViewModel()
        {
            SearchResults = new List<DealerInventory>();
            ResultsPerPage = 500;
            PageNum = 1;
            OrderBy = "DatePosted";
            Ascending = "Desc";
        }

        public Customer CustomerInfo { get; set; }

        public IList<DealerEmployee> DealerEmployees { get; set; }

        public SalesInfoViewModel SalesInfo { get; set; }

        public List<MonthlyMetric> MonthToDateMetrics { get; set; }

        public List<DailyRevenue> MonthlyRevenue { get; set; }

        public List<YearlyMetric> YearToDateMetrics { get; set; }

        public List<UnitsSold> UnitsSoldMetrics { get; set; }

        public List<MonthlyRevenue> YearlyRevenue { get; set; }

        public Decimal CalculateUnitsSoldBarWidth(UnitsSold unit) {
            if (UnitsSoldMetrics == null || UnitsSoldMetrics.Count == 0)
                return 0;

            return (decimal)unit.Units / (decimal)UnitsSoldMetrics[0].Units * 100; 
        }

        public int CalculateMonthlyRevenueDivWidth()
        {
            DateTime date = DateTime.Now;
            decimal month = date.Month;
            decimal year = date.Year;
            decimal day = date.Day;
            decimal days = DateTime.DaysInMonth((int)year, (int)month);
            decimal result = day / days * 100;

            return (int)Math.Ceiling(result);
        }

        public int CalculateYearlyRevenueDivWidth()
        {
            double month = DateTime.Now.Month;
            return (int)Math.Ceiling(month / 12.0 * 100);
        }

        public decimal GetYearToDateMetric(int i)
        {
            if (i >= 0 && i < YearToDateMetrics.Count)
                return YearToDateMetrics[i].Total;

            return 0;
        }
    }
}
