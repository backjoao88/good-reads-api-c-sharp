using GoodReads.Core.Enumerations;
using Microsoft.AspNetCore.Authorization;

namespace GoodReads.Api.Attributes;

/// <summary>
/// Custom attribute to define if an user has permission to access an endpoint.
/// </summary>
public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(params ERole[] roles)
    {
        var loweredRoles = roles.Select(o => o.ToString().ToLower());
        Roles = string.Join(", ", loweredRoles);
    }
}