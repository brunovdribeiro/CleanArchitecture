namespace CleanArchitecture.Contract.Employees;

public record EmployeeResponse(Guid Id, string Name, string Email, bool IsActive) { }