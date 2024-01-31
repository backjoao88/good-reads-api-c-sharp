using GoodReads.Infrastructure.ExternalBookSource.Contracts;
using GoodReads.Infrastructure.ExternalBookSource.Dtos;

namespace GoodReads.Infrastructure.ExternalBookSource.Implementations;

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
    /// <returns>A list of <see cref="BookSourceDto"/></returns>
    public async Task<List<BookSourceDto>> GetBooks(string query)
    {
        var responseMessage = await _bookSourceClient.GetAsync(query);
        var responseString = await responseMessage.Content.ReadAsStringAsync();
        var bookSourceDtos = await _bookSourceClient.SerializeAsync(responseString);
        return bookSourceDtos;
    }
}