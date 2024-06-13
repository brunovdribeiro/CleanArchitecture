namespace CleanArchitecture.Application.Employees.Commands.CreateEmployee;

public record CreateEmployeeCommandResponse(Guid Id, string Name, string Email, bool IsActive);