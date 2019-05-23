using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models.Metrics
{
    public class MonthlyRevenue
    { 
        [Key]
        public int Month { get; set; }

        public Decimal Revenue { get; set; }
    }
}
