using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class QInventoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public bool Commercial { get; set; }

        [Required]
        public int QInventoryMakeId { get; set; }

        public QInventoryMake Make { get; set; }

        [Required]
        public int TypeId { get; set; }

        public QInventoryType Type { get; set; }
    }
}
