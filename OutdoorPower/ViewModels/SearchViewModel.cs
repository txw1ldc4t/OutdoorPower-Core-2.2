using Microsoft.AspNetCore.Mvc.Rendering;
using OutdoorPower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.ViewModels
{
    public abstract class SearchViewModel
    {
        public string Ascending { get; set; }

        public int DealerId { get; set; }

        public string EngineBrand { get; set; }

        public List<SelectListItem> EngineBrandList { get; set; }

        public int? HorsePowerMax { get; set; }

        public int? HorsePowerMin { get; set; }

        public bool? IsSold { get; set; }

        public string KeyWords { get; set; }

        public Int16? MinHours { get; set; }

        public Int16? MaxHours { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public Int16? MinYear { get; set; }

        public Int16? MaxYear { get; set; }

        public int NavStart { get; set; }

        public int NavEnd { get; set; }

        public string OrderBy { get; set; }

        public Int16 PageNum { get; set; }

        public int QType { get; set; }

        public IList<SelectListItem> TypeList { get; set; }

        public int QMake { get; set; }

        public string QMakeOther { get; set; }

        public IEnumerable<SelectListItem> MakeList { get; set; }

        public int QModel { get; set; }

        public string QModelOther { get; set; }

        public IEnumerable<SelectListItem> ModelList { get; set; }

        public int QModelOption { get; set; }

        public string QModelOptionOther { get; set; }

        public IEnumerable<SelectListItem> QModelOptionList { get; set; }

        public string ZipCode { get; set; }

        public int QZipCodeRadius { get; set; }

        public Int16 ResultsPerPage { get; set; }

        public Int32 TotalResults { get; set; }

        public IList<DealerInventory> SearchResults { get; set; }
    }
}
