namespace SimpleSubscription.Application.DTOs;

public class SubscriptionDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PlanId { get; set; }
    public string Status { get; set; } = string.Empty;
}