using FluentValidation;
using ChuksKitchen.Application.Users.Commands;

public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        RuleFor(x => x.PhoneNumber).MinimumLength(11).NotEmpty();
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
    }
}