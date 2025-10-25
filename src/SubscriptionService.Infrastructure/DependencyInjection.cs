using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleSubscription.Infrastructure.Data;
using SimpleSubscription.Infrastructure.Repositories;

namespace SimpleSubscription.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("subscriptions-db"));

        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

        return services;
    }
}