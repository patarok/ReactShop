using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactShop.Server.Domain.Entities;

namespace ReactShop.Server.Data.Configurations;

public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        // One-to-Many Relationship: Manufacturer -> Products
        builder.HasMany(m => m.Products)
            .WithOne(p => p.Manufacturer)
            .HasForeignKey(p => p.ManufacturerId)
            .IsRequired();
    }
}