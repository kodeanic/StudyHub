using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure;

public static class InfrastructureInitializer
{
    public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
    {
        Log.Information("Add Infrastructure services");

        InitializeDb(services, configuration);

        return services;
    }

    private static void InitializeDb(
        IServiceCollection services,
        IConfiguration configuration)
    {
        var section = configuration.GetSection("DATABASE");

        var dbHost = section["DBHOST"] ?? string.Empty;
        var dbPort = section["DBPORT"] ?? string.Empty;
        var dbDatabase = section["DBNAME"] ?? string.Empty;
        var dbUsername = section["USER"] ?? string.Empty;
        var dbPassword = section["PASSWORD"] ?? string.Empty;

        var dbConnectionString = $"Host={dbHost};Port={dbPort};Database={dbDatabase};Username={dbUsername};Password={dbPassword}";

        try
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(dbConnectionString));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        }
        catch (Exception exception)
        {
            Log.Error(exception, $"Adding database to WebApp\n" + $"\t{dbConnectionString}");
            throw;
        }
    }
}
