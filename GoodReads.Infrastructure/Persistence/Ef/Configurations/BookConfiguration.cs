using GoodReads.Core.Entities;
using GoodReads.Core.Primitives;
using GoodReads.Infrastructure.Persistence.Ef.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReads.Infrastructure.Persistence.Ef.Configurations;

/// <summary>
/// Represents a <see cref="Book"/> configuration.
/// </summary>
public class BookConfiguration : EntityBaseConfiguration<Book>
{
    /// <summary>
    /// Configure a book entity on EFCore.
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Book");
        builder.HasMany(o => o.Ratings).WithOne().HasForeignKey(o => o.IdBook);
        builder.Property(o => o.Description).HasMaxLength(250);
        builder.Property(o => o.Title).HasMaxLength(250);
        builder.Property(o => o.Isbn).HasMaxLength(250);
        builder.HasIndex(o => o.Isbn).IsUnique();
    }
}