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
}