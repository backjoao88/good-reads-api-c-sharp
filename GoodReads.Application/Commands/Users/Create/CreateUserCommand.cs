using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Users.Create;

/// <summary>
/// Represents a command to create an user.
/// </summary>
public class CreateUserCommand : IRequest<Result>
{
    public CreateUserCommand(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}