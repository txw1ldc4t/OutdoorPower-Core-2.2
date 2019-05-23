using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class DealerInventoryImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string WebPath { get; set; }

        // Foreign key 
        [Display(Name = "DealerInventory")]
        public int DealerInventoryId { get; set; }

    }
}
