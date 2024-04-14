using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace Application;

public static class ApplicationInitializer
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        Log.Information("Add Application services");

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
