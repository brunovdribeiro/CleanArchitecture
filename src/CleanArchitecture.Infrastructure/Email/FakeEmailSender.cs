using CleanArchitecture.Application.Common.Interfaces.Services;

using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Email;

public class FakeEmailSender(ILogger<FakeEmailSender> _logger) : IEmailSender
{
    public Task SendEmailAsync(string to, string from, string subject, string body)
    {
        _logger.LogInformation("Not actually sending an email to {To} from {From} with subject {Subject}", to, from, subject);

        return Task.CompletedTask;
    }
}