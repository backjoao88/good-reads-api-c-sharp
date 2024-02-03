using GoodReads.Core.Entities;
using GoodReads.Infrastructure.Persistence.Ef.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReads.Infrastructure.Persistence.Ef.Configurations.Entities;

/// <summary>
/// Represents a <see cref="User"/> configuration.
/// </summary>
public class UserConfiguration : EntityBaseConfiguration<User>
{
    /// <summary>
    /// Configure a rating entity on EFCore.
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_User");
        builder.Property(o => o.FirstName).HasMaxLength(250);
        builder.Property(o => o.LastName).HasMaxLength(250);
        builder.Property(o => o.Email).HasMaxLength(250);
        builder.Property(o => o.Password).HasMaxLength(250);
    } 
}