using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class DealerEmployee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName {get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        public int DealerId { get; set; }
        public int DealerEmployeeTypeId { get; set; }
        public Guid DealerEmployeeLoginCredentialsId { get; set; }

    }
}
