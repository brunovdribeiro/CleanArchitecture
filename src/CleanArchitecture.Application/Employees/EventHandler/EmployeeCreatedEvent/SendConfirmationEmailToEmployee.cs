using CleanArchitecture.Application.Common.Interfaces.Services;

using MediatR;

namespace CleanArchitecture.Application.Employees.EventHandler.EmployeeCreatedEvent;

public class SendSecondEmail(IEmailSender emailSender)
    : INotificationHandler<Domain.Events.Employees.EmployeeCreatedEvent>
{
    private const string From = "noreply@test.com";
    private const string Subject = "Second Email Confirmation";
    private const string Body = "Welcome to Clean Architecture";

    public async Task Handle(Domain.Events.Employees.EmployeeCreatedEvent notification,
        CancellationToken cancellationToken)
    {
        await emailSender.SendEmailAsync(notification.Employee.Email, From, Subject, Body);
    }
}