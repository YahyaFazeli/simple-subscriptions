using FluentValidation;

namespace SimpleSubscription.Application.DTOs;

public class SubscribeRequest
{
    public int UserId { get; set; }
    public int PlanId { get; set; }
}

public class SubscribeRequestValidator : AbstractValidator<SubscribeRequest>
{
    public SubscribeRequestValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.PlanId).GreaterThan(0);
    }
}
