using CleanArchitecture.Application.Common.Interfaces.Data;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;

using MediatR;

namespace CleanArchitecture.Application.Employees.Queries;

public class GetEmployeesWithPaginationHandler(IEmployeeRepository employeeRepository)
    : IRequestHandler<GetEmployeesWithPagination, PaginatedList<EmployeeDto>>
{
    public Task<PaginatedList<EmployeeDto>> Handle(GetEmployeesWithPagination request, CancellationToken cancellationToken)
    {
        return employeeRepository
            .AllEmployees()
            .OrderBy(x => x.Name)
            .Select(x => new EmployeeDto(x.Id, x.Name, x.Email, x.IsActive))
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}