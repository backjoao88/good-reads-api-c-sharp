using GoodReads.Application.ViewModel;
using GoodReads.Core.Contracts;
using GoodReads.Core.Primitives;
using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Queries.Books.DownloadCover;

public class DownloadCoverQueryHandler : IRequestHandler<DownloadCoverQuery, Result<BookDownloadCoverViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DownloadCoverQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<BookDownloadCoverViewModel>> Handle(DownloadCoverQuery request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetById(request.IdBook);
        if (book is null)
        {
            return Result.Fail<BookDownloadCoverViewModel>(DomainErrors.Book.BookNotFoundError);
        }
        if (book.Cover is null)
        {
            return Result.Fail<BookDownloadCoverViewModel>(DomainErrors.Book.BookCoverEmptyError);
        }
        var memoryStream = new MemoryStream(book.Cover);
        var bookDownloadCoverViewModel = new BookDownloadCoverViewModel(memoryStream);
        return Result.Ok(bookDownloadCoverViewModel);
    }
}