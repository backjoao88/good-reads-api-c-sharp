using GoodReads.Core.Enumerations;

namespace GoodReads.Application.Abstractions.Authentication;

/// <summary>
/// Represents a contract to generate JWT tokens.
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Generate a new Jwt Token with Hmac512 algorithm encryption.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns>A JWT string token</returns>
    public string Generate(int userId, string role);
    /// <summary>
    /// Computes a new Sha512 string with the required input.
    /// </summary>
    /// <param name="input"></param>
    /// <returns>A Sha512 string</returns>
    public string Encrypt(string input);
}