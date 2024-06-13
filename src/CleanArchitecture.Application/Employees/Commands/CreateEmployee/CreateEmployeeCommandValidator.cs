using FluentValidation;

namespace CleanArchitecture.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(200)
            .MinimumLength(3);

        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
    }
}