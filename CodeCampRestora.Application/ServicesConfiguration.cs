using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCampRestora.Application;

public static class ServicesConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var currentExecutingAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssembly(currentExecutingAssembly);
        });

        return services;
    }
}