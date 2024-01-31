using GoodReads.Application.Commands.Books.UpdateCover;
using GoodReads.Core.Contracts;
using GoodReads.Core.Primitives;
using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Books.UploadCover;

/// <summary>
/// Represents the <see cref="UploadCoverCommand"/> handler.
/// </summary>
public class UploadCoverCommandHandler : IRequestHandler<UploadCoverCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UploadCoverCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UploadCoverCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetById(request.IdBook);
        if (book is null)
        {
            return Result.Fail(DomainErrors.Book.BookNotFoundError);
        }
        var requestedStream = request.Stream;
        byte[] coverBytes = new byte[requestedStream.Length];
        var _ = await requestedStream.ReadAsync(coverBytes);
        book.UpdateCover(coverBytes);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}