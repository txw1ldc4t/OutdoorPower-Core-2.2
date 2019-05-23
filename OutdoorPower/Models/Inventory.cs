using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public abstract class Inventory
    {
        public int Id { get; set; }

        public int DealerId { get; set; }

        [StringLength(20, ErrorMessage = "A maximum of 20 characters is allowed for serial number.")]
        public string SerialNumber { get; set; }

        public int QInventoryTypeId { get; set; }

        [Required]
        public QInventoryType Type { get; set; }

        public int? Year { get; set; }

        public int? QInventoryMakeId { get; set; }

        public QInventoryMake Make { get; set; }

        [StringLength(150, ErrorMessage = "A maximum of 100 characters allowed for other brand.")]
        public string QInventoryMakeOther { get; set; }

        public int? QInventoryModelId { get; set; }

        public QInventoryModel Model { get; set; }

        [StringLength(100, ErrorMessage = "A maximum of 100 characters allowed for other model.")]
        public string QInventoryModelOther { get; set; }

        public int? QInventoryModelOptionId { get; set; }

        //IE Trim
        public QInventoryModelOption ModelOption { get; set; }

        // IE. TrimOther
        [StringLength(100, ErrorMessage = "A maximum of 100 characters allowed.")]
        public string QInventoryModelOptionOther { get; set; }

        [StringLength(150, ErrorMessage = "A maximum of 150 characters allowed for engine brand.")]
        public string EngineBrand { get; set; }

        [StringLength(30, ErrorMessage = "A maximum of 30 characters allowed for horse power.")]
        public string EngineHorsePower { get; set; }

        public int? EngineHours { get; set; }

        public Decimal Price { get; set; }

        public DateTime DatePosted { get; set; }

        [StringLength(15, ErrorMessage = "A maximum of 15 characters is allowed for zip code.")]
        public string ZipCode { get; set; }

        public Int16? Fuel { get; set; }

        public Int16? Condition { get; set; }

        public Decimal? WholeSalePrice { get; set; }
    }
}
