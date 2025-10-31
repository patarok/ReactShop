using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactShop.Server.Domain.Entities;

namespace ReactShop.Server.Data.Configurations;

public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        // FK-Beziehung zu Product
        builder.HasOne(ol => ol.Product)
            .WithMany() // Product hat eine Collection von OrderLines
            .HasForeignKey(ol => ol.ProductId)
            .IsRequired();
        
        // Dezimal-Präzision (NetUnitPrice: decimal(19, 2))
        builder.Property(ol => ol.NetUnitPrice)
            .HasColumnType("decimal(19, 2)")
            .IsRequired();
        
        // Dezimal-Präzision (TaxRate: decimal(9, 2))
        builder.Property(ol => ol.TaxRate)
            .HasColumnType("decimal(9, 2)")
            .IsRequired();
    }
}