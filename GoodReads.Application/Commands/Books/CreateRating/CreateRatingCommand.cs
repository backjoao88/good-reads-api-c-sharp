using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Books.CreateRating;

/// <summary>
/// Represents a command to create a new rating.
/// </summary>
public class CreateRatingCommand : IRequest<Result>
{
    public CreateRatingCommand(string description, int rate, int idBook, int idUser)
    {
        Description = description;
        Rate = rate;
        IdBook = idBook;
        IdUser = idUser;
    }
    public string Description { get; set; }
    public int Rate { get; set; }
    public int IdBook { get; set; }
    public int IdUser { get; set; }
}