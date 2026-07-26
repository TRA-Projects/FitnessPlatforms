using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface ISubscriptionRepository
    {
        // Get all subscriptions
        Task<IEnumerable<Subscription>> GetAllSubscriptions();

        // Get subscription by id
        Task<Subscription?> GetSubscriptionById(int id);

        // Create new subscription
        Task<Subscription> CreateSubscription(Subscription subscription);

        // Update subscription
        Task UpdateSubscription(Subscription subscription);

        // Delete subscription
        Task DeleteSubscription(int id);
    }
}
