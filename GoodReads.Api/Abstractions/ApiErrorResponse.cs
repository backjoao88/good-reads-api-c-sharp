using GoodReads.Core.Primitives;

namespace GoodReads.Api.Abstractions;

/// <summary>
/// Represents an error response for the global exception handler.
/// </summary>
public class ApiErrorResponse
{
    private readonly Error[] _errors;

    public ApiErrorResponse(Error[] errors)
    {
        _errors = errors;
    }
}