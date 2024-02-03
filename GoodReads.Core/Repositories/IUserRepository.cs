using GoodReads.Core.Entities;

namespace GoodReads.Core.Repositories;

/// <summary>
/// Represents a contract of a user repository.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Save an user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Task Save(User user);
    
    /// <summary>
    /// Checks if e-mail is unique.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public Task<bool> IsEmailUnique(string email);
    
    /// <summary>
    /// Checks if the e-mail and password matches with any kept.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="hashedPassword"></param>
    /// <returns></returns>
    public Task<User?> MatchEmailAndPassword(string email, string hashedPassword);
}