using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;

using MediatR;

namespace CleanArchitecture.Application.Employees.Queries;

public record GetEmployeesWithPagination(int PageNumber = 1, int PageSize = 5) : IRequest<PaginatedList<Employee>>
{
}