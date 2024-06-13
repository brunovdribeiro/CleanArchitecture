using CleanArchitecture.Domain.Common.Bases;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.Employees;

public class EmployeeCreatedEvent(Employee employee) : EventBase
{
    public Employee Employee { get; } = employee;
}