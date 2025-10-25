using SimpleSubscription.Application.Common;
using SimpleSubscription.Application.DTOs;

namespace SimpleSubscription.Application.Interfaces;

public interface ISubscriptionService
{
    Task<Result<IEnumerable<PlanDto>>> GetPlansAsync();
    Task<Result<SubscriptionDto>> GetActiveSubscriptionAsync(int userId);
    Task<Result<SubscriptionDto>> SubscribeAsync(int userId, int planId);
    Task<Result> CancelSubscriptionAsync(int userId);
}
