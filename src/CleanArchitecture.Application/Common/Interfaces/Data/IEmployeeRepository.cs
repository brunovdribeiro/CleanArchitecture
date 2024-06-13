using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces.Data;

public interface IEmployeeRepository
{
    Task Add(Employee employee);
    IQueryable<Employee> AllEmployees();
}