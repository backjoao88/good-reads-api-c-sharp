using FluentValidation;

namespace GoodReads.Application.Commands.Books.Create;

/// <summary>
/// Represents the <see cref="CreateBookCommand"/> validator.
/// </summary>
public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(o => o.Description).NotEmpty();
        RuleFor(o => o.Isbn).NotEmpty();
        RuleFor(o => o.Title).NotEmpty();
    }    
}