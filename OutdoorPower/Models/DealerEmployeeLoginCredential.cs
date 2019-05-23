using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class DealerEmployeeLoginCredential : IdentityUser
    {
        [Required]
        public int DealerEmployeeId { get; set; }
    }
}
