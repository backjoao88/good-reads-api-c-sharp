using System.ComponentModel.DataAnnotations.Schema;
using GoodReads.Core.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;

namespace GoodReads.Infrastructure.Persistence.Ef.Abstractions;

/// <summary>
/// Represents an entity base configuration.
/// </summary>
public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    
    /// <summary>
    /// Specify a primary key 'ID' for all derived configurations.
    /// </summary>
    /// <param name="builder"></param>
    /// <exception cref="NotImplementedException"></exception>
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedOnAdd();
    }
}