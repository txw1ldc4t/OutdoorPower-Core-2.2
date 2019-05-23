using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models.Metrics
{
    public class DailyRevenue
    {
        [Key]
        public int Day { get; set; }

        public Decimal Revenue { get; set; }
    }
}
