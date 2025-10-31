using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ReactShop.Server.Domain.Entities;

public class Category
{
    [Key]
    public int Id { get; set; } // Note: SQL shows no IDENTITY, but EF Core can infer it or rely on convention. We will assume IDENTITY for simplicity, but if the old app managed IDs manually, we'd adjust the data seeding.

    [MaxLength(200)]
    [Required]
    public string Name { get; set; } = null!;

    // decimal(9, 2)
    public decimal TaxRate { get; set; } 

    // Navigation Property: Category has many Products
    public ICollection<Product> Products { get; set; } = new List<Product>();
}