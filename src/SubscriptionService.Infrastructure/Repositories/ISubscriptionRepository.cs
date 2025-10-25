using SimpleSubscription.Domain.Entities;

namespace SimpleSubscription.Infrastructure.Repositories;

public interface ISubscriptionRepository
{
    Task<IEnumerable<Plan>> GetPlansAsync();
    Task<Plan?> GetPlanByIdAsync(int planId);
    Task<Subscription?> GetActiveSubscriptionAsync(int userId);
    Task<Subscription> AddSubscriptionAsync(int userId, int planId);
    Task CancelSubscriptionAsync(int userId);
}
