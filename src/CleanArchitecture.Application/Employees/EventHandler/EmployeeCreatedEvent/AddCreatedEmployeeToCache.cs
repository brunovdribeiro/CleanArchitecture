using MediatR;

using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Employees.EventHandler.EmployeeCreatedEvent;

public class AddCreatedEmployeeToCache(ILogger<AddCreatedEmployeeToCache> logger)
    : INotificationHandler<Domain.Events.Employees.EmployeeCreatedEvent>
{
    public Task Handle(Domain.Events.Employees.EmployeeCreatedEvent notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Employee {Name} added to cache.", notification.Employee.Name);

        return Task.CompletedTask;
    }
}