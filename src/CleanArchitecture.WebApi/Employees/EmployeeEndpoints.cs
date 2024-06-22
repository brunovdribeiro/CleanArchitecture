namespace CleanArchitecture.WebApi.Employees;

public static class EmployeeEndpoints
{
    public static WebApplication MapEmployeesEndpoints(this WebApplication app)
    {
        var endpoint = app.MapGroup("api/employees/");

        endpoint.MapGet("/", () => "Oi");

        return app;
    }
}