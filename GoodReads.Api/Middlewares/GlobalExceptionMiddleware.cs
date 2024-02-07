using System.Net;
using System.Text.Json;
using GoodReads.Api.Abstractions;
using GoodReads.Application.Exceptions;
using GoodReads.Core.Primitives;

namespace GoodReads.Api.Middlewares;

public class GlobalExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var response = JsonSerializer.Serialize(exception.Errors, options);
            await context.Response.WriteAsync(response);
        }
        catch (Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var response = JsonSerializer.Serialize(new Error("Server.UnknownError", exception.Message), options);
            await context.Response.WriteAsync(response);
        }
    }
}