using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInitializer
{
    public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=Assignment;Username=postgres;Password=password"));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
