using System.Text.Json;
using GoodReads.Infrastructure.ExternalBookSource.Contracts;
using GoodReads.Infrastructure.ExternalBookSource.Dtos;

namespace GoodReads.Infrastructure.ExternalBookSource.Clients;

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
    /// <returns></returns>
    public async Task<HttpResponseMessage> GetAsync(string query)
    {
        const string REQUIRED_RESOURCE = "volumes";
        var queryParams = new Dictionary<string, string>()
        {
            {"q", query }
        };
        var queryParamsFormUrlEncoded = new FormUrlEncodedContent(queryParams);
        var queryParamsString = await queryParamsFormUrlEncoded.ReadAsStringAsync();
        string requestUrl = $"{REQUIRED_RESOURCE}?{queryParamsString}";
        return await _client.GetAsync(requestUrl);  
    }

    /// <summary>
    /// Serializes a json string content based on a string response.
    /// </summary>
    /// <param name="content"></param>
    /// <returns>A list of <see cref="BookSourceDto"/></returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<List<BookSourceDto>> SerializeAsync(string content)
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
        var bookSourceDtos = new List<BookSourceDto>();
        if (items.Count() > 0)
        {
            bookSourceDtos = items
                .Select(item => item.TryGetProperty("volumeInfo", out var volumeInfoProperty) ? volumeInfoProperty : new JsonElement())
                .Select(item => new
                {
                    Title = item.TryGetProperty("title", out var nameProperty) ? nameProperty.GetString() : "",
                    Publisher = item.TryGetProperty("publisher", out var publisherProperty) ? publisherProperty.GetString() : "",
                })
                .Select(item => new BookSourceDto(item.Title, item.Publisher))
                .ToList();        
        }
        return await Task.FromResult(bookSourceDtos);
    }
}