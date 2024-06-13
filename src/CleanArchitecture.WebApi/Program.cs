using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.WebApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddPresentation()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

WebApplication app = builder.Build();

app.MapHealthChecks("/health");
app.UseExceptionHandler(options => { });
app.UseHttpsRedirection();
app.MapControllers();

app.Run();