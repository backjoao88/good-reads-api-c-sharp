using GoodReads.Application.ViewModel;
using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Queries.Books.DownloadCover;

/// <summary>
/// Represents the command to download a saved cover.
/// </summary>
public class DownloadCoverQuery : IRequest<Result<BookDownloadCoverViewModel>>
{
    public DownloadCoverQuery(int idBook)
    {
        IdBook = idBook;
    }
    public int IdBook { get; set; }
}