using GoodReads.Application.ViewModel;
using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Users.Login;

/// <summary>
/// Represents a login command.
/// </summary>
public class LoginUserCommand : IRequest<Result<LoginViewModel>>
{
    public LoginUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}