using GoodReads.Core.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace GoodReads.Api.Abstractions;

public class ApiController : ControllerBase
{
    [NonAction]
    public IActionResult BadRequest(Error error) => BadRequest(error.Message);
}