﻿using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureInitializer
{
    public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
    {
        return services;
    }
}
