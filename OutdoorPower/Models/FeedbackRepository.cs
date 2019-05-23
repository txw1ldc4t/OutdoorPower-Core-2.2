using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class FeedbackRepository: IFeedbackRepository
    {
        private readonly OutdoorPowerContext _appDbContext;
        public FeedbackRepository(OutdoorPowerContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddFeedback(Feedback feedback)
        {
            _appDbContext.Feedbacks.Add(feedback);
            _appDbContext.SaveChanges();
        }
    }
}
