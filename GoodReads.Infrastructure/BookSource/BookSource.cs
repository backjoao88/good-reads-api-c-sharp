using GoodReads.Application.Abstractions.BookSource;
using GoodReads.Infrastructure.BookSource.Contracts;

namespace GoodReads.Infrastructure.BookSource;

/// <summary>
/// Represents the service to retrieve books from a external source.
/// </summary>
public class BookSource : IBookSource
{
    private readonly IBookSourceClient _bookSourceClient;

    public BookSource(IBookSourceClient bookSourceClient)
    {
        _bookSourceClient = bookSourceClient;
    }

    /// <summary>
    /// Coordinates the actions needed to retrieve a list of books from an external source.
    /// The actions involved are mainly the get request and serialization tasks.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <returns>A list of <see cref="BookSourceRequest"/></returns>
    public async Task<List<BookSourceRequest>> GetBooks(string query, int offset = 0, int limit = 20)
    {
        var responseMessage = await _bookSourceClient.GetAsync(query, offset, limit);
        var responseString = await responseMessage.Content.ReadAsStringAsync();
        var bookSourceDtos = await _bookSourceClient.SerializeAsync(responseString);
        return bookSourceDtos;
    }
}