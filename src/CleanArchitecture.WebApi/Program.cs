using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.WebApi;
using CleanArchitecture.WebApi.Employees;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddPresentation()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder
    .Build()
    .UsePresentation()
    .MapEmployeesEndpoints()
    .Run();

public partial class Program
{
}