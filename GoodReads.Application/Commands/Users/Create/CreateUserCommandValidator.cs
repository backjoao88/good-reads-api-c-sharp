using FluentValidation;

namespace GoodReads.Application.Commands.Users.Create;

/// <summary>
/// Represents the <see cref="CreateUserCommand"/> validator.
/// </summary>
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(o => o.FirstName).NotEmpty();
        RuleFor(o => o.LastName).NotEmpty();
        RuleFor(o => o.Email).NotEmpty();
        RuleFor(o => o.Password).NotEmpty();
        RuleFor(o => o.Role).NotEmpty();
    }
}