using GoodReads.Core.Enumerations;
using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Books.Create;

/// <summary>
/// Represents a command to create a new book.
/// </summary>
public class CreateBookCommand : IRequest<Result>
{
    public CreateBookCommand(string title, string description, string isbn, EBookGenre genre)
    {
        Title = title;
        Description = description;
        Isbn = isbn;
        Genre = genre;
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Isbn { get; set; }
    public EBookGenre Genre { get; set; }
}