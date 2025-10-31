using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactShop.Server.Domain.Entities;

namespace ReactShop.Server.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Relationship to Manufacturer (One-to-Many)
        // Note: The one side is configured in ManufacturerConfiguration, but we ensure the FK here
        builder.HasOne(p => p.Manufacturer)
            .WithMany(m => m.Products)
            .HasForeignKey(p => p.ManufacturerId)
            .IsRequired();

        // Relationship to Category (One-to-Many)
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired()
            .HasConstraintName("FK_Product_Category"); // Optional: Use old SQL constraint name
        
        // Map decimal precision to match SQL schema
        builder.Property(p => p.NetUnitPrice)
            .HasColumnType("decimal(19, 2)");
    }
}