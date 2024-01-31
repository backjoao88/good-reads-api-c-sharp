using GoodReads.Infrastructure.ExternalBookSource.Dtos;

namespace GoodReads.Infrastructure.ExternalBookSource.Contracts;

/// <summary>
/// Represents a book source contract.
/// </summary>
public interface IBookSourceClient
{
    public Task<HttpResponseMessage> GetAsync(string query);
    public Task<List<BookSourceDto>> SerializeAsync(string content);
}