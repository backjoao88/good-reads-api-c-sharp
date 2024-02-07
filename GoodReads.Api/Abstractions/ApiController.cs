using System.Security.Claims;
using GoodReads.Application.Abstractions.Authentication;
using GoodReads.Core.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Abstractions;

/// <summary>
/// Represents a generic API controller.
/// </summary>
public class ApiController : ControllerBase
{
    [NonAction]
    public IActionResult BadRequest(Error error) => BadRequest(error.Message);

    [NonAction]
    public int GetAuthenticatedUserId()
    {
        var userSubjectClaim = User.Claims.FirstOrDefault(o => o.Type == JwtClaimTypes.Subject)?.Value;
        if (userSubjectClaim is null)
        {
            throw new ArgumentException();
        }
        if (!Int32.TryParse(userSubjectClaim, out int userId))
        {
            throw new ArgumentException();
        }
        return userId;
    }
}