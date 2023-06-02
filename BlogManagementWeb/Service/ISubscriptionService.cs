using Models;

namespace BlogManagementWeb.Service
{
    public interface ISubscriptionService { 
     Task<IEnumerable<Subscription>> GetSubscriptionsAsync();
    Task<Subscription> GetSubscriptionByIdAsync(int id);
    Task<Subscription> CreateSubscriptionAsync(Subscription sub);

    Task DeleteSubscriptionAsync(int id);
}
}
