using GoodReads.Api.Abstractions;
using GoodReads.Application.Commands.Users.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Controllers;

/// <summary>
/// Handles users requests.
/// </summary>
[ApiController]
[Route("/api/users")]
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
        return await Task.FromResult(Ok());
    }
}