using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SubscriptionRepository(ApplicationDbContext _dbContext):base(_dbContext)
        {
            dbContext = _dbContext;
        }
        public void Update(Subscription sub)
        {
            dbContext.Subscriptionss.Update(sub);
        }
    }
}
