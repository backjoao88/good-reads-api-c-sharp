using GoodReads.Core.Contracts;
using GoodReads.Core.Entities;
using GoodReads.Core.Primitives;
using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Books.CreateRating;

/// <summary>
/// Represents the <see cref="CreateRatingCommand"/> handler.
/// </summary>
public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRatingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetById(request.IdBook);
        if (book is null)
        {
            return Result.Fail(DomainErrors.Book.BookNotFoundError);
        }
        var rating = new Rating(request.Description, request.Rate, request.IdBook);
        var resultCorrectRange = rating.IsInCorrectRange();
        if (resultCorrectRange.IsFailure)
        {
            return resultCorrectRange;
        }
        await _unitOfWork.BookRepository.SaveRating(rating);
        /* Recalculate the average rating before it saves */
        book.RecalculateRate();
        /**/
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}