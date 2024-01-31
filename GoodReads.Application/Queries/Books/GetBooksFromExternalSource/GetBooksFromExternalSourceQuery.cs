using GoodReads.Application.ViewModel;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetBooksFromExternalSource;

/// <summary>
/// Represents a query to return a set of books from an external data source. 
/// </summary>
public class GetBooksFromExternalSourceQuery : IRequest<List<BookSimpleViewModel>>
{
    public GetBooksFromExternalSourceQuery(string query)
    {
        Query = query;
    }
    public string Query { get; set; }
}