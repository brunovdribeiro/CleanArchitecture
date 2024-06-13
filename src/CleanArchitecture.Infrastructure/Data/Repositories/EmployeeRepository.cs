using CleanArchitecture.Application.Common.Interfaces.Data;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Data.Repositories;

public class EmployeeRepository(AppDbContext appDbContext) : IEmployeeRepository
{
    public Task Add(Employee employee)
    {
        appDbContext.Employees.Add(employee);

        return Task.CompletedTask;
    }

    public IQueryable<Employee> AllEmployees()
    {
        return appDbContext.Employees.Where(x => !x.IsDeleted);
    }
}