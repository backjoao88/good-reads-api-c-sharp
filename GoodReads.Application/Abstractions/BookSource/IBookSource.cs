namespace GoodReads.Application.Abstractions.BookSource;

/// <summary>
/// Represents a book source contract.
/// </summary>
public interface IBookSource
{
    /// <summary>
    /// Get the books from a specific resource.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    public Task<List<BookSourceRequest>> GetBooks(string query, int offset, int limit);
}