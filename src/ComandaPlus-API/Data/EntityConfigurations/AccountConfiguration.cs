using ComandaPlus_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComandaPlus_API.EntityConfigurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(k => k.Id);
        builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Logo).HasMaxLength(250);
        builder.Property(p => p.Identifier).HasMaxLength(20).IsRequired();

        builder.HasOne(e => e.Owner).WithMany(e => e.Accounts)
            .HasForeignKey(k => k.OwnerId);
        builder.HasOne(e => e.License).WithMany(e => e.Accounts)
            .HasForeignKey(k => k.LicenseId);
    }
}
