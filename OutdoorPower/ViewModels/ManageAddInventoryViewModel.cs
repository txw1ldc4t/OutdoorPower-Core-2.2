using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OutdoorPower.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OutdoorPower.ViewModels
{
    public class ManageAddInventoryViewModel
    {
        private string price;

        public ManageAddInventoryViewModel()
        {
            EngineHorsePowerList = new List<SelectListItem>();
            ImageList = new List<DealerInventoryImage>();
            ModelList = new List<SelectListItem>();
            ModelOptionList = new List<SelectListItem>();
            OPTPublic = true;
        }

        [Required]
        public string Title { get; set; }

        public int Id { get; set; }

        public List<IFormFile> Images { get; set; }

        public List<DealerInventoryImage> ImageList { get; set; }

        public string SerialNumber { get; set; }

        [Required]
        public int QInventoryTypeId { get; set; }

        public QInventoryType Type { get; set; }

        public IList<SelectListItem> TypeList { get; set; }

        public int Year { get; set; }

        public IList<SelectListItem> YearList { get; set; }

        public int? QInventoryMakeId { get; set; }

        public QInventoryMake Make { get; set; }

        public IList<SelectListItem> MakeList { get; set; }

        [StringLength(150, ErrorMessage = "A maximum of 100 characters allowed for other brand.")]
        public string QInventoryMakeOther { get; set; }

        public int? QInventoryModelId { get; set; }

        public QInventoryModel Model { get; set; }

        public IList<SelectListItem> ModelList { get; set; }

        [StringLength(100, ErrorMessage = "A maximum of 100 characters allowed for other model.")]
        public string QInventoryModelOther { get; set; }

        public int? QInventoryModelOptionId { get; set; }

        //IE Trim
        public QInventoryModelOption ModelOption { get; set; }

        public IList<SelectListItem> ModelOptionList { get; set; }

        // IE. TrimOther
        [StringLength(100, ErrorMessage = "A maximum of 100 characters allowed.")]
        public string QInventoryModelOptionOther { get; set; }

        [StringLength(150, ErrorMessage = "A maximum of 150 characters allowed for engine brand.")]
        public string EngineBrand { get; set; }

        public IList<SelectListItem> EngineBrandList { get; set; }

        [StringLength(30, ErrorMessage = "A maximum of 30 characters allowed for horse power.")]
        public string EngineHorsePower { get; set; }

        public IList<SelectListItem> EngineHorsePowerList { get; set; }

        public string EngineHours { get; set; }

        [StringLength(1000, ErrorMessage = "A maximum of 1000 characters is allowed for the description.")]
        public string Description { get; set; }

        public Boolean OPTPublic { get; set; }

        [DataType(DataType.Currency)]
        public String Price {
            get {
                if (price != null)
                    return price.Replace("$", "");

                return "";
            }
            set { price = value; }
        }

        public DateTime DatePosted { get; set; }

        public string ZipCode { get; set; }

        public Dealer DealerInfo { get; set; }

        public Int16 Fuel { get; set; }

        public Int16 Condition { get; set; }

        public string Warranty { get; set; }
    }
}
