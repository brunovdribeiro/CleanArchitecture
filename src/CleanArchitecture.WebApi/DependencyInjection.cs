using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.WebApi.Configurations;

namespace CleanArchitecture.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddHealthChecks().AddDbContextCheck<AppDbContext>();
        services.AddExceptionHandler<CustomExceptionHandler>();

        return services;
    }

    public static WebApplication UsePresentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.MapHealthChecks("/health");
        app.UseExceptionHandler(options => { });
        app.UseHttpsRedirection();
        // app.MapControllers();
        
        return app;
    }
}