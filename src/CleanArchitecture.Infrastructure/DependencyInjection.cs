using CleanArchitecture.Application.Common.Interfaces.Data;
using CleanArchitecture.Application.Common.Interfaces.Services;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Data.Interceptors;
using CleanArchitecture.Infrastructure.Data.Repositories;
using CleanArchitecture.Infrastructure.Email;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IEmailSender, FakeEmailSender>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        string? connectionString = configuration.GetConnectionString("CleanArchitectureConnection");

        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            ISaveChangesInterceptor? interceptors = serviceProvider.GetService<ISaveChangesInterceptor>();

            if (interceptors is not null)
            {
                options.AddInterceptors(interceptors);
            }

            options.UseNpgsql(connectionString);
        });

        return services;
    }
}