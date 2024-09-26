using System;
using ComandaPlus_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComandaPlus_Data.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Password).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Status).HasConversion<sbyte>().IsRequired();
        builder.Property(u => u.Role).HasConversion<sbyte>().IsRequired();
        builder.Property(u => u.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(u => u.LastLogin).HasColumnType("datetime");
    }
}
