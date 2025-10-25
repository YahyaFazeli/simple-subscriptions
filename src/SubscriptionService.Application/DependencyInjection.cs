using Microsoft.Extensions.DependencyInjection;
using SimpleSubscription.Application.Interfaces;
using SimpleSubscription.Application.Services;

namespace SimpleSubscription.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ISubscriptionService, SubscriptionService>();
        return services;
    }
}
