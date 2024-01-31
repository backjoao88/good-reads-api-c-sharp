using GoodReads.Infrastructure.ExternalBookSource.Dtos;

namespace GoodReads.Infrastructure.ExternalBookSource.Contracts;

/// <summary>
/// Represents a book source contract.
/// </summary>
public interface IBookSource
{
    public Task<List<BookSourceDto>> GetBooks(string query);
}