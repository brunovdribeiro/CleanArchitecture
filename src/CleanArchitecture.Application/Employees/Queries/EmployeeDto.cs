namespace CleanArchitecture.Application.Employees.Queries;

public record EmployeeDto(Guid Id, string Name, string Email, bool IsActive)
{
}