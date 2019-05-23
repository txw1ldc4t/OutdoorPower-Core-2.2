using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models.Metrics
{
    public class DealerMetric
    {
        [Key]
        public int Id { get; set; }

        public int DealerId { get; set; }
    }
}
