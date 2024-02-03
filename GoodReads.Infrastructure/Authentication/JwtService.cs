using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GoodReads.Application.Abstractions.Authentication;
using GoodReads.Infrastructure.Authentication.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GoodReads.Infrastructure.Authentication;

/// <summary>
/// Represents a implementation of a JWT token generator.
/// </summary>
public class JwtService : IJwtService
{
    private readonly JwtOptions _jwtOptions;

    public JwtService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions!.Value;
    }

    /// <inheritdoc/>
    public string Generate(int userId, string role)
    {
        var audience = _jwtOptions.Audience;
        var issuer = _jwtOptions.Issuer;
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        var signingCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        var jwtHeader = new JwtHeader(signingCredentials);
        var claims = new List<Claim>()
        {
            new("userId", Convert.ToString(userId)),
            new("role", role ?? string.Empty),
        };
        var jwtPayload = new JwtPayload(issuer, audience, claims, new DateTime(), new DateTime().AddMinutes(5));
        var jwtSecurityToken = new JwtSecurityToken(jwtHeader, jwtPayload);
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
    
    /// <inheritdoc/>
    public string Encrypt(string input)
    {
        var crypt = SHA256.Create();
        var encryptedBytes = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder stringBuilder = new StringBuilder();
        foreach(var chunk in encryptedBytes)
        {
            // x2 = hexadecimal
            stringBuilder.Append($"{chunk:X2}");
        }
        return stringBuilder.ToString();
    }
}