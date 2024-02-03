using GoodReads.Application.Abstractions.Authentication;
using GoodReads.Application.ViewModel;
using GoodReads.Core.Contracts;
using GoodReads.Core.Enumerations;
using GoodReads.Core.Primitives;
using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Users.Login;

/// <summary>
/// Represents the <see cref="LoginUserCommand"/> handler.
/// </summary>
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginViewModel>>
{
    private IUnitOfWork _unitOfWork;
    private IJwtService _jwtService;

    public LoginUserCommandHandler(IJwtService jwtService, IUnitOfWork unitOfWork)
    {
        _jwtService = jwtService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<LoginViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = _jwtService.Encrypt(request.Password);
        var user = await _unitOfWork.UserRepository.MatchEmailAndPassword(request.Email, hashedPassword);
        if (user is null)
        {
            return Result.Fail<LoginViewModel>(DomainErrors.User.UserInvalidEmailOrPassword);
        }
        var roleStr = Enum.GetName(typeof(ERole), user.Role);
        var jwt = _jwtService.Generate(user.Id, roleStr ?? "");
        var loginViewModel = new LoginViewModel(Convert.ToString(user.Id), jwt);
        return Result.Ok(loginViewModel);
    }
}