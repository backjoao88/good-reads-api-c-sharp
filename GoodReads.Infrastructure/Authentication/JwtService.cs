using GoodReads.Application.Abstractions.Authentication;
using GoodReads.Core.Enumerations;

namespace GoodReads.Infrastructure.Authentication;

/// <summary>
/// Represents a implementation of a JWT token generator.
/// </summary>
public class JwtService : IJwtService
{
    public string Generate(int userId, ERole role)
    {
        throw new NotImplementedException();
    }

    public string ComputeSha256(string input)
    {
        throw new NotImplementedException();
    }
}