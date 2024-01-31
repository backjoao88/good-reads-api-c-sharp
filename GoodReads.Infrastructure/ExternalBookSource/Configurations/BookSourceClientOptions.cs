using GoodReads.Infrastructure.ExternalBookSource.Contracts;

namespace GoodReads.Infrastructure.ExternalBookSource.Configurations;

/// <summary>
/// Represents a set of configurations to <see cref="IBookSource"/> 
/// </summary>
public class BookSourceClientOptions
{
    public string BaseUrl { get; set; } = string.Empty;
}