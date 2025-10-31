using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactShop.Server.Domain.Entities;

namespace ReactShop.Server.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.PriceTotal)
            .HasColumnType("decimal(28, 2)")
            .IsRequired();

        // Order has many OrderLines
        builder.HasMany(o => o.OrderLines)
            .WithOne(ol => ol.Order)
            .HasForeignKey(ol => ol.OrderId)
            .OnDelete(DeleteBehavior.Cascade) // delete lines when order is deleted
            .IsRequired();

        // Order belongs to an Identity user
        builder.HasOne(o => o.User)
            .WithMany() // no Orders collection on ApplicationUser
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict) // don’t cascade delete orders if a user is deleted
            .IsRequired();

        // Optional but recommended
        builder.HasIndex(o => o.UserId);
    }
}