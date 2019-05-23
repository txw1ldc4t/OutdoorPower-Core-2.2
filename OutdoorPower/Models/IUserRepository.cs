using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public interface IUserRepository
    {
        Dealer GetDealer(int Id);
        IList<DealerEmployee> GetUsers(int dealerId);
    }
}
