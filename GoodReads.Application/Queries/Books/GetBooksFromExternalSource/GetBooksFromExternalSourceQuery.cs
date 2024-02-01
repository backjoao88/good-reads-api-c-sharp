using GoodReads.Application.ViewModel;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetBooksFromExternalSource;

/// <summary>
/// Represents a query to return a set of books from an external data source. 
/// </summary>
public class GetBooksFromExternalSourceQuery : IRequest<List<BookSimpleViewModel>>
{
    public GetBooksFromExternalSourceQuery(string query, int offset, int limit)
    {
        Query = query;
        Offset = offset;
        Limit = limit;
    }
    public string Query { get; set; }
    public int Offset { get; set; }
    public int Limit { get; set; }
}