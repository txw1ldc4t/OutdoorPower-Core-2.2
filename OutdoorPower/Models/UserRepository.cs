using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly OutdoorPowerContext _appDbContext;
        public UserRepository(OutdoorPowerContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Dealer GetDealer(int Id)
        {
            return _appDbContext.Dealers.Where(d => d.Id == Id).FirstOrDefault();
        }

        public IList<DealerEmployee> GetUsers(int dealerId)
        {
            return _appDbContext.DealerEmployees.Where(d => d.DealerId == dealerId).ToList();
        }
    }
}
