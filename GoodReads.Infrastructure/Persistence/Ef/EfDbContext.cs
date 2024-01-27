using GoodReads.Core.Entities;
using GoodReads.Infrastructure.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GoodReads.Infrastructure.Persistence.Ef;

/// <summary>
/// Represents a implementation of the EF db context.
/// </summary>
public class EfDbContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Rating> Ratings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new RatingConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-N7P7NAN\\SQLEXPRESS01;User=sa;Database=goodreadsdb;Password=joao#123;TrustServerCertificate=true;");
    }
}