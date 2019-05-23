using OutdoorPower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.ViewModels
{
    public class UsersViewModel
    {
        public IList<DealerEmployee> Users { get; set; }
        public ModifyUser EditUser { get; set; }
    }
}
