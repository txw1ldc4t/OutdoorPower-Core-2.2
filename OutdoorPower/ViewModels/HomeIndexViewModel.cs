using Microsoft.AspNetCore.Mvc.Rendering;
using OutdoorPower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; }

        public int QType { get; set; }

        public IList<SelectListItem> TypeList { get; set; }

        public int QMake { get; set; }

        public IEnumerable<SelectListItem> MakeList { get; set; }

        public int QModel { get; set; }

        public int QDeck { get; set; }

        public string ZipCode { get; set; }

        public int QZipCodeRadius { get; set; }
    }
}
