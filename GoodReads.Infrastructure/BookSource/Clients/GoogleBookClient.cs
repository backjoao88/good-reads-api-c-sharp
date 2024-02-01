using System.Text.Json;
using GoodReads.Application.Abstractions.BookSource;
using GoodReads.Infrastructure.BookSource.Contracts;

namespace GoodReads.Infrastructure.BookSource.Clients;

/// <summary>
/// Represents a implementation of the Google Books API client.
/// </summary>
public class GoogleBookClient : IBookSourceClient
{
    private readonly HttpClient _client;

    public GoogleBookClient(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Get method to retrieve data from a specific resource.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> GetAsync(string query, int offset, int limit)
    {
        const string requiredResource = "volumes";
        string offsetStr = Convert.ToString(offset);
        string limitStr = Convert.ToString(limit);
        var queryParams = new Dictionary<string, string>()
        {
            {"q", query },
            {"startIndex", offsetStr},
            {"maxResults", limitStr}
        };
        var queryParamsFormUrlEncoded = new FormUrlEncodedContent(queryParams);
        var queryParamsString = await queryParamsFormUrlEncoded.ReadAsStringAsync();
        string requestUrl = $"{requiredResource}?{queryParamsString}";
        return await _client.GetAsync(requestUrl);  
    }

    /// <summary>
    /// Serializes a json string content based on a string response.
    /// </summary>
    /// <param name="content"></param>
    /// <returns>A list of <see cref="BookSourceRequest"/></returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<List<BookSourceRequest>> SerializeAsync(string content)
    {
        if (!content.Any())
        {
            throw new ArgumentException();
        }
        
        JsonElement root;
        try
        {
            root = JsonDocument.Parse(content).RootElement;
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Parsing serialization error. {e.Message}");
        }
        
        if (root.ValueKind != JsonValueKind.Object)
        { 
            throw new ArgumentException();
        }
        
        var items = root.TryGetProperty("items", out var tmpItems)
            ? tmpItems.EnumerateArray()
            : new JsonElement.ArrayEnumerator();
        var bookSourceDtos = new List<BookSourceRequest>();
        if (items.Count() > 0)
        {
            bookSourceDtos = items
                .Select(item => item.TryGetProperty("volumeInfo", out var volumeInfoProperty) ? volumeInfoProperty : new JsonElement())
                .Select(item => new
                {
                    Title = item.TryGetProperty("title", out var nameProperty) ? nameProperty.GetString() : "",
                    Publisher = item.TryGetProperty("publisher", out var publisherProperty) ? publisherProperty.GetString() : "",
                })
                .Select(item => new BookSourceRequest(item.Title, item.Publisher))
                .ToList();        
        }
        return await Task.FromResult(bookSourceDtos);
    }
}