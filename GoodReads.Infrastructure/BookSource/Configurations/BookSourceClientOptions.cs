using GoodReads.Application.Abstractions.BookSource;

namespace GoodReads.Infrastructure.BookSource.Configurations;

/// <summary>
/// Represents a set of configurations to <see cref="IBookSource"/> 
/// </summary>
public class BookSourceClientOptions
{
    public string BaseUrl { get; set; } = string.Empty;
}