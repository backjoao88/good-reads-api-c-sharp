using GoodReads.Core.Entities;
using GoodReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoodReads.Infrastructure.Persistence.Ef.Repositories;

/// <summary>
/// Represents a concrete repository implementation for <see cref="User"/> entity.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly EfDbContext _dbContext;

    public UserRepository(EfDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task Save(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }
    
    /// <inheritdoc />
    public async Task<bool> IsEmailUnique(string email)
    {
        return !await _dbContext.Users.AnyAsync(o => o.Email == email);
    }

    /// <inheritdoc />
    public async Task<User?> MatchEmailAndPassword(string email, string hashedPassword)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(o => o.Email == email && o.Password == hashedPassword);
    }
}