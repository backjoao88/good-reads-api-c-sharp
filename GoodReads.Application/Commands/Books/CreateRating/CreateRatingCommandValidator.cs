using FluentValidation;

namespace GoodReads.Application.Commands.Books.CreateRating;

/// <summary>
/// Represents the <see cref="CreateRatingCommand"/> validator.
/// </summary>
public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
{
    public CreateRatingCommandValidator()
    {
        RuleFor(o => o.Rate).NotEmpty();
        RuleFor(o => o.Description).NotEmpty();
    }
}