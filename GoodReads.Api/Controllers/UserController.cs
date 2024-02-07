using GoodReads.Api.Abstractions;
using GoodReads.Api.Attributes;
using GoodReads.Application.Commands.Users.Create;
using GoodReads.Application.Commands.Users.Login;
using GoodReads.Core.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Controllers;

/// <summary>
/// Handles users requests.
/// </summary>
[ApiController]
[Route("/api/users")]
[HasPermission(ERole.Admin)]
public class UserController : ApiController
{

    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint used to save a new user in the database.
    /// </summary>
    /// <param name="createUserCommand"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserCommand)
    {
        var result = await _mediator.Send(createUserCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint used to sign in.
    /// </summary>
    /// <param name="loginUserCommand"></param>
    /// <returns></returns>
    [HttpPut("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Put([FromBody] LoginUserCommand loginUserCommand)
    {
        var resultLoginViewModel = await _mediator.Send(loginUserCommand);
        return resultLoginViewModel.IsSuccess ? Ok(resultLoginViewModel.Data) : BadRequest(resultLoginViewModel.Error);
    }
}