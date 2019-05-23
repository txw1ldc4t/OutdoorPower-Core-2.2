using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your name is required.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Email address is required.")]
        [RegularExpression(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "A message is required.")]
        [MaxLength(1000)]
        public string Message { get; set; }
        public bool ContactMe { get; set; }
    }
}
