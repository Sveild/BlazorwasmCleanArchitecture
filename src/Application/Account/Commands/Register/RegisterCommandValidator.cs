using FluentValidation;

namespace BlazorwasmCleanArchitecture.Application.Account.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().Length(8, 100);
        RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password);
    }
}