using GoodReads.Core.Entities;
using GoodReads.Infrastructure.Persistence.Ef.Configurations;
using GoodReads.Infrastructure.Persistence.Ef.Configurations.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodReads.Infrastructure.Persistence.Ef;

/// <summary>
/// Represents a implementation of the EF db context.
/// </summary>
public class EfDbContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Rating> Ratings { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    
    /// <summary>
    /// Required by EFCore.
    /// </summary>
    protected EfDbContext()
    {
    }

    /// <summary>
    /// Sets up a db context with options.
    /// </summary>
    /// <param name="options"></param>
    public EfDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new RatingConfiguration());
    }
}