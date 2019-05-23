using Microsoft.AspNetCore.Mvc.Rendering;
using OutdoorPower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.ViewModels
{
    public class HomeSearchViewModel : SearchViewModel
    {
        public HomeSearchViewModel() {
            SearchResults = new List<DealerInventory>();
            ResultsPerPage = 20;
            PageNum = 1;
        }
    }
}
