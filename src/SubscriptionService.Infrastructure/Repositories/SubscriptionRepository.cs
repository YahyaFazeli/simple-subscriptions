using Microsoft.EntityFrameworkCore;
using SimpleSubscription.Domain.Entities;
using SimpleSubscription.Domain.Enums;
using SimpleSubscription.Infrastructure.Data;

namespace SimpleSubscription.Infrastructure.Repositories;

public class SubscriptionRepository(ApplicationDbContext dbContext) : ISubscriptionRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Plan>> GetPlansAsync()
    {
        return await _dbContext.Plans
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Plan?> GetPlanByIdAsync(int planId)
    {
        return await _dbContext.Plans
            .AsNoTracking()
            .Where(s => s.Id == planId)
            .FirstOrDefaultAsync();
    }

    public async Task<Subscription?> GetActiveSubscriptionAsync(int userId)
    {
        return await _dbContext.Subscriptions
            .AsNoTracking()
            .Where(s => s.UserId == userId)
            .Where(s => s.Status == SubscriptionStatus.Active)
            .FirstOrDefaultAsync();
    }

    public async Task<Subscription> AddSubscriptionAsync(int userId, int planId)
    {
        Subscription subscription = new(userId, planId);
        _dbContext.Subscriptions.Add(subscription);
        await _dbContext.SaveChangesAsync();
        return subscription;
    }

    public async Task CancelSubscriptionAsync(int userId)
    {
        var subscription = await _dbContext.Subscriptions
            .Where(s => s.UserId == userId)
            .Where(s => s.Status == SubscriptionStatus.Active)
            .FirstOrDefaultAsync();

        if (subscription is not null)
        {
            subscription.Status = SubscriptionStatus.Cancelled;
            await _dbContext.SaveChangesAsync();
        }
    }
}
