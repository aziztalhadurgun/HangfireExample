using Hangfire;
using HangfireExample.Application.Interfaces;
using HangfireExample.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HangfireExample.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddHangfire(config =>
        {
            config.UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"));
        });
        services.AddHangfireServer();

        services.AddTransient<IJobScheduler, JobScheduler>();

        return services;
    }
}
