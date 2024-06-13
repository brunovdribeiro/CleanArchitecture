using CleanArchitecture.Application.Common.Interfaces.Data;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events.Employees;

using MediatR;

namespace CleanArchitecture.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateEmployeeCommand, CreateEmployeeCommandResponse>
{
    public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        Employee employee = Employee.CreateInstance(request.Name, request.Email);

        await employeeRepository.Add(employee);

        employee.AddDomainEvent(new EmployeeCreatedEvent(employee));

        employee.Delete();

        await unitOfWork.SaveChanges();

        return new CreateEmployeeCommandResponse(employee.Id, employee.Name, employee.Email, employee.IsActive);
    }
}