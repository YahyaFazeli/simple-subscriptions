using FluentValidation;
using SimpleSubscription.Application;
using SimpleSubscription.Application.DTOs;
using SimpleSubscription.Infrastructure;

namespace SimpleSubscription.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        services.AddValidatorsFromAssemblyContaining<SubscribeRequestValidator>();
        return services;
    }
}
