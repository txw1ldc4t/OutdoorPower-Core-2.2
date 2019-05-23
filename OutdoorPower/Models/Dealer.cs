using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class Dealer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(150)]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(150)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        public string Zip { get; set; }

        [Required]
        [StringLength(25)]
        public string PhoneNumber { get; set; }

        [StringLength(500)]
        public string Website { get; set; }

        [StringLength(256)]
        public string Email { get; set; }
    }
}
