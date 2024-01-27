﻿using GoodReads.Core.Entities;
using GoodReads.Infrastructure.Persistence.Ef.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReads.Infrastructure.Persistence.Ef.Configurations;

/// <summary>
/// Represents a <see cref="Rating"/> configuration.
/// </summary>
public class RatingConfiguration : EntityBaseConfiguration<Rating>
{
    /// <summary>
    /// Configure a rating entity on EFCore.
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityTypeBuilder<Rating> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Rating");
        builder.Property(o => o.Description).HasMaxLength(250);
    }   
}