using GoodReads.Core.Enumerations;

namespace GoodReads.Application.Abstractions.Authentication;

/// <summary>
/// Represents a contract to generate JWT tokens.
/// </summary>
public interface IJwtService
{
    public string Generate(int userId, ERole role);
    public string ComputeSha256(string input);
}