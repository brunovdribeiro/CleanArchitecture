using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.WebApi.Configurations;

namespace CleanArchitecture.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<AppDbContext>();
        services.AddExceptionHandler<CustomExceptionHandler>();

        return services;
    }
}