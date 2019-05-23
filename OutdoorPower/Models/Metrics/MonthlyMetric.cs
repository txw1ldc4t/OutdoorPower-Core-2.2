using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models.Metrics
{
    public class MonthlyMetric {
        public Decimal Total { get; set; }

        [Key]
        public int Week { get; set; }
    }
}
