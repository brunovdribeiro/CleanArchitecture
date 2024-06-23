using CleanArchitecture.Application.Common.Interfaces.Data;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;

using MediatR;

namespace CleanArchitecture.Application.Employees.Queries;

public class GetEmployeesWithPaginationHandler(IEmployeeRepository employeeRepository)
    : IRequestHandler<GetEmployeesWithPagination, PaginatedList<Employee>>
{
    public Task<PaginatedList<Employee>> Handle(GetEmployeesWithPagination request, CancellationToken cancellationToken)
    {
        return employeeRepository
            .AllEmployees()
            .OrderBy(x => x.Name)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}