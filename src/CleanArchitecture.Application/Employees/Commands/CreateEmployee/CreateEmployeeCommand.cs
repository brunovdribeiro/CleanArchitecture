using MediatR;

namespace CleanArchitecture.Application.Employees.Commands.CreateEmployee;

public record CreateEmployeeCommand(string Name, string Email) : IRequest<CreateEmployeeCommandResponse>;