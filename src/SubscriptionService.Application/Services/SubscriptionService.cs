using SimpleSubscription.Application.DTOs;
using SimpleSubscription.Application.Interfaces;
using SimpleSubscription.Infrastructure.Repositories;
using SimpleSubscription.Application.Common;

namespace SimpleSubscription.Application.Services;

public class SubscriptionService(ISubscriptionRepository repository) : ISubscriptionService
{
    private readonly ISubscriptionRepository _repository = repository;

    public async Task<Result<IEnumerable<PlanDto>>> GetPlansAsync()
    {
        var plans = await _repository.GetPlansAsync();
        var result = plans.Select(p => new PlanDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        });

        return Result<IEnumerable<PlanDto>>.Success(result);
    }

    public async Task<Result<SubscriptionDto>> GetActiveSubscriptionAsync(int userId)
    {
        var subscription = await _repository.GetActiveSubscriptionAsync(userId);
        if (subscription is null)
            return Result<SubscriptionDto>.Failure("User does not have an active subscription.");

        var result = new SubscriptionDto
        {
            Id = subscription.Id,
            UserId = subscription.UserId,
            PlanId = subscription.PlanId,
            Status = subscription.Status.ToString()
        };

        return Result<SubscriptionDto>.Success(result);
    }

    public async Task<Result<SubscriptionDto>> SubscribeAsync(int userId, int planId)
    {
        var plan = await _repository.GetPlanByIdAsync(planId);
        if (plan is null)
            return Result<SubscriptionDto>.Failure("Plan does not exist.");

        var existingSubscription = await _repository.GetActiveSubscriptionAsync(userId);
        if (existingSubscription is not null)
            return Result<SubscriptionDto>.Failure("User already has an active subscription.");

        var subscription = await _repository.AddSubscriptionAsync(userId, planId);

        var dto = new SubscriptionDto
        {
            Id = subscription.Id,
            UserId = subscription.UserId,
            PlanId = subscription.PlanId,
            Status = subscription.Status.ToString()
        };

        return Result<SubscriptionDto>.Success(dto);
    }

    public async Task<Result> CancelSubscriptionAsync(int userId)
    {
        var activeSubscription = await _repository.GetActiveSubscriptionAsync(userId);
        if (activeSubscription is null)
            return Result.Failure("User does not have an active subscription.");

        await _repository.CancelSubscriptionAsync(userId);
        return Result.Success();
    }
}
