using GoodReads.Application.Abstractions.Authentication;
using GoodReads.Core.Contracts;
using GoodReads.Core.Entities;
using GoodReads.Core.Primitives;
using GoodReads.Core.Primitives.Result;
using MediatR;

namespace GoodReads.Application.Commands.Users.Create;

/// <summary>
/// Represents the <see cref="CreateUserCommand"/> handler.
/// </summary>
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IJwtService jwtService)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (!await _unitOfWork.UserRepository.IsEmailUnique(request.Email))
        {
            return Result.Fail(DomainErrors.User.UserEmailAlreadyTaken);
        }
        var passwordHashed = _jwtService.Encrypt(request.Password);
        var user = new User(request.FirstName, request.LastName, request.Email, passwordHashed, request.Role);
        await _unitOfWork.UserRepository.Save(user);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}