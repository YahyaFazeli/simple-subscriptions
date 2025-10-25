using SimpleSubscription.Domain.Enums;

namespace SimpleSubscription.Domain.Entities;

public sealed class Subscription : Entity
{
    public int UserId { get; set; }
    public int PlanId { get; set; }
    public SubscriptionStatus Status { get; set; }

    private Subscription() { }

    public Subscription(int userId, int planId)
    {
        UserId = userId;
        PlanId = planId;
        Status = SubscriptionStatus.Active;
    }
}
