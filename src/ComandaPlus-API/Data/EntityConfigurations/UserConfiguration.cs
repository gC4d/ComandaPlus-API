using ComandaPlus_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComandaPlus_API.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Status).HasConversion<sbyte>().IsRequired();
        builder.Property(u => u.Role).HasConversion<sbyte>().IsRequired();
        builder.Property(u => u.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(u => u.LastLogin).HasColumnType("datetime");
    }
}
