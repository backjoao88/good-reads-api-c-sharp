namespace GoodReads.Application.Abstractions.BookSource;

/// <summary>
/// Represents a return response from <see cref="IBookSource"/>
/// </summary>
/// <param name="Title"></param>
/// <param name="Publisher"></param>
public record BookSourceRequest(string? Title, string? Publisher);