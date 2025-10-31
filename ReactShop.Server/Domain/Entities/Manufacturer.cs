using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ReactShop.Server.Domain.Entities;

public class Manufacturer
{
    [Key] // Explicitly marks Id as PK, although convention handles it
    public int Id { get; set; }

    [MaxLength(200)]
    [Required] // Name is NOT NULL
    public string Name { get; set; } = null!;

    // Navigation Property: Manufacturer has many Products
    public ICollection<Product> Products { get; set; } = new List<Product>();
}