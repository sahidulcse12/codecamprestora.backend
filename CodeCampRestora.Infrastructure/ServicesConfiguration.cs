using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CodeCampRestora.Infrastructure.Data.DbContexts;

namespace CodeCampRestora.Infrastructure;

public static class ServicesConfiguration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStringKey = "LocalDbContext";
        var assemblyName = "CodeCampRestora.Api";
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(connectionStringKey),
                b => b.MigrationsAssembly(assemblyName));
        });

        return services;
    }
}