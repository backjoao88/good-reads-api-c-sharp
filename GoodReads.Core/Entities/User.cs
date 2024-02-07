using GoodReads.Core.Enumerations;
using GoodReads.Core.Primitives;

namespace GoodReads.Core.Entities;

/// <summary>
/// Represents a user
/// </summary>
public class User : Entity
{
    public User(string firstName, string lastName, string email, string password, ERole role)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Role = role;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ERole Role { get; set; }
}