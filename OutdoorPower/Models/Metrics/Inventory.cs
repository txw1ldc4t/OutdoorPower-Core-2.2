using OutdoorPower.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models.Metrics
{
    public class Inventory : Models.Inventory
    {
        public Inventory(){

        }

        public Decimal? PriceSold { get; set; }

        public DateTime? DateSold { get; set; }

        // This is the Dealer Employee id that sold the inventory 
        public int? DealerEmployeeId { get; set; }

        public SalesType? SalesType { get; set; }

        public int OPInventoryId { get; set; }
    }
}
