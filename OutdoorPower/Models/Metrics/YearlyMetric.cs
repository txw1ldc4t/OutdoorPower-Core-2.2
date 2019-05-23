using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models.Metrics
{
    public class YearlyMetric
    {
        public Decimal Total { get; set; }

        [Key]
        public int Month { get; set; }

        public string MonthName
        {
            get
            {
                return new DateTime(2019, Month, 1).ToString("MMMM");
            }
        }
    }
}
