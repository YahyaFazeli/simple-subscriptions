using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimpleSubscription.Application.DTOs;
using SimpleSubscription.Application.Interfaces;
using SimpleSubscription.Application.Common;

namespace SimpleSubscription.API.Endpoints;

public static class SubscriptionEndpoints
{
    public static void MapSubscriptionEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/subscriptions");

        // Get available plans
        group.MapGet("/plans", async (
            [FromServices] ISubscriptionService service) =>
        {
            var plans = await service.GetPlansAsync();
            return Results.Ok(plans);
        });

        // Get subscribed plan
        group.MapGet("/{userId}", async (
            [FromRoute] int userId,
            [FromServices] ISubscriptionService service) =>
        {
            var result = await service.GetActiveSubscriptionAsync(userId);
            return result.IsSuccess ? Results.Ok(result) : Results.NotFound(result);
        });

        // Subscribe to a plan
        group.MapPost("/", async (
            [FromBody] SubscribeRequest request,
            [FromServices] IValidator<SubscribeRequest> validator,
            [FromServices] ISubscriptionService service) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Results.BadRequest(Result.Failure(errors));
            }

            var result = await service.SubscribeAsync(request.UserId, request.PlanId);

            return !result.IsSuccess
                ? Results.Conflict(result)
                : Results.Created($"/api/subscriptions/{result.Value!.Id}", result);
        });

        // Cancel subscription
        group.MapDelete("/{userId}", async (
            [FromRoute] int userId,
            [FromServices] ISubscriptionService service) =>
        {
            var result = await service.CancelSubscriptionAsync(userId);

            return !result.IsSuccess
                ? Results.NotFound(result)
                : Results.NoContent();
        });
    }
}
