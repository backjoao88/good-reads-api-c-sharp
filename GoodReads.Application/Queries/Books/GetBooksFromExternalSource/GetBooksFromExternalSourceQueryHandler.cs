using GoodReads.Application.ViewModel;
using GoodReads.Infrastructure.ExternalBookSource.Contracts;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetBooksFromExternalSource;

/// <summary>
/// Represents the <see cref="GetBooksFromExternalSourceQuery"/> handler.
/// </summary>
public class GetBooksFromExternalSourceQueryHandler : IRequestHandler<GetBooksFromExternalSourceQuery, List<BookSimpleViewModel>>
{
    private readonly IBookSource _bookSource;

    public GetBooksFromExternalSourceQueryHandler(IBookSource bookSource)
    {
        _bookSource = bookSource;
    }

    public async Task<List<BookSimpleViewModel>> Handle(GetBooksFromExternalSourceQuery request, CancellationToken cancellationToken)
    {
        var bookSourceDtos = await _bookSource.GetBooks(request.Query);
        var bookSimpleViewModels = bookSourceDtos
            .Select(o => new BookSimpleViewModel(o.Title ?? "", o.Publisher ?? ""))
            .ToList();
        return bookSimpleViewModels;
    }
}