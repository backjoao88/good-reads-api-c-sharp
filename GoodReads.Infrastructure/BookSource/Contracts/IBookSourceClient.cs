using GoodReads.Application.Abstractions.BookSource;

namespace GoodReads.Infrastructure.BookSource.Contracts;

/// <summary>
/// Represents a book source contract.
/// </summary>
public interface IBookSourceClient
{
    public Task<HttpResponseMessage> GetAsync(string query, int offset, int limit);
    public Task<List<BookSourceRequest>> SerializeAsync(string content);
}