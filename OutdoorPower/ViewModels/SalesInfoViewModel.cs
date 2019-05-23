using OutdoorPower.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.ViewModels
{
    public class SalesInfoViewModel
    {
        public Decimal PriceSold { get; set; }

        public DateTime DateSold { get; set; }

        // This is the Dealer Employee id that sold the inventory 
        public int DealerEmployeeId { get; set; }

        public SalesType SalesType { get; set; }

        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(1)]
        public string MiddleInitial { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(5)]
        public string Zip { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(25)]
        public string PhoneNumber { get; set; }

        public Int16 PhoneType { get; set; }

        public int OPInventoryId { get; set; }
    }
}
