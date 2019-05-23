using OutdoorPower.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.ViewModels
{
    public class SalesInfoModalViewModel
    {
        public int Id { get; set; }

        public Decimal? PriceSold { get; set; }

        public DateTime? DateSold { get; set; }

        // This is the Dealer Employee id that sold the inventory 
        public int? DealerEmployeeId { get; set; }

        public SalesType? SalesType { get; set; }
    }
}
