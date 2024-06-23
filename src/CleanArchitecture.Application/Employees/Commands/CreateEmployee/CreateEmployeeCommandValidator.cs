using FluentValidation;

namespace CleanArchitecture.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(200);

        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
    }
}