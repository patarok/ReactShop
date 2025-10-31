using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactShop.Server.Domain.Entities;
using ReactShop.Server.Identity; // Notwendig, da Sie ApplicationUser verwenden

namespace ReactShop.Server.Data.Configurations;

public class CustomerProfileConfiguration : IEntityTypeConfiguration<CustomerProfile>
{
    // Diese Methode enthält den gesamten Mapping-Code
    public void Configure(EntityTypeBuilder<CustomerProfile> builder)
    {
        // 1. Primärschlüssel-Definition
        builder.HasKey(cp => cp.Id);

        // 2. Die One-to-One-Beziehung zum ApplicationUser (Identity User)
        builder.HasOne(cp => cp.User)
            .WithOne(u => u.CustomerProfile)
            .HasForeignKey<CustomerProfile>(cp => cp.UserId)
            .IsRequired();

        // 3. Spalten-Eigenschaften
        builder.Property(cp => cp.DisplayName).HasMaxLength(200);
        builder.Property(cp => cp.City).HasMaxLength(100);
        builder.Property(cp => cp.Country).HasMaxLength(100);
    }
}