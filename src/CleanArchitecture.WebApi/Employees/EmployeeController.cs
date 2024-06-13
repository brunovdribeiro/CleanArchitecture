using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Employees.Commands.CreateEmployee;
using CleanArchitecture.Application.Employees.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Employees;

[Route("employees")]
[ApiController]
public class EmployeeController(ISender _mediator) : ControllerBase
{
    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<PaginatedList<EmployeeDto>> Get(int pageNumber, int pageSize)
    {
        GetEmployeesWithPagination query = new GetEmployeesWithPagination(pageNumber, pageSize);

        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<CreateEmployeeCommandResponse> Create(CreateEmployeeCommand request)
    {
        CreateEmployeeCommand command = new CreateEmployeeCommand(request.Name, request.Email);

        return await _mediator.Send(command);
    }
}