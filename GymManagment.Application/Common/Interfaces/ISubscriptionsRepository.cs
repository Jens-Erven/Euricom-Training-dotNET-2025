using GymManagment.Domain.Subscriptions;

namespace GymManagment.Application.Common.Interfaces
{
    public interface ISubscriptionsRepository
    {
        Task AddSubscriptionAsync(Subscription subscription);
        Task<Subscription?> GetByIdAsync(Guid subscriptionId);
    }
}
