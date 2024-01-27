using GoodReads.Core.Contracts;
using GoodReads.Core.Entities;
using GoodReads.Core.Primitives;
using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Books.Create;

/// <summary>
/// Represents the <see cref="CreateBookCommand"/> handler.
/// </summary>
public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var resultIsbnUnique = await _unitOfWork.BookRepository.IsIsbnUnique(request.Isbn);
        if (!resultIsbnUnique)
        {
            return Result.Fail(DomainErrors.Book.IsbnNotUniqueError);
        }
        var book = new Book(request.Title, request.Description, request.Isbn, request.Genre);
        await _unitOfWork.BookRepository.Save(book);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}