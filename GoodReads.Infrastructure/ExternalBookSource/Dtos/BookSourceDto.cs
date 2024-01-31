using GoodReads.Infrastructure.ExternalBookSource.Contracts;

namespace GoodReads.Infrastructure.ExternalBookSource.Dtos;

/// <summary>
/// Represents a book source DTO from <see cref="IBookSourceClient"/>
/// </summary>
public class BookSourceDto
{
    public BookSourceDto(string? title, string? publisher)
    {
        Title = title;
        Publisher = publisher;
    }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
}