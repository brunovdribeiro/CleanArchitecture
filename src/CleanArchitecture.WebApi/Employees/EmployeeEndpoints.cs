using CleanArchitecture.Application.Employees.Commands.CreateEmployee;
using CleanArchitecture.Application.Employees.Queries;
using CleanArchitecture.Contract.Employees;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Employees;

public static class EmployeeEndpoints
{
    public static WebApplication MapEmployeesEndpoints(this WebApplication app)
    {
        var endpoint = app.MapGroup("api/employees/");

        endpoint.MapGet("{pageNumber:int}/{pageSize:int}", async (
            ISender mediator, 
            int pageNumber, 
            int pageSize) =>
        {
            GetEmployeesWithPagination query = new GetEmployeesWithPagination(pageNumber, pageSize);

            return await mediator.Send(query);
        });

        endpoint.MapPost("/", async (
            ISender mediator, 
            CreateEmployeeRequest request) =>
        {
            CreateEmployeeCommand command = new CreateEmployeeCommand(request.Name, request.Email);
        
            return await mediator.Send(command);
        });

        return app;
    }
}