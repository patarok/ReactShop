using System.ComponentModel.DataAnnotations;

namespace ReactShop.Server.Domain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; } 

    [MaxLength(200)]
    [Required]
    public string Name { get; set; } = null!;

    // decimal(19, 2)
    public decimal NetUnitPrice { get; set; }

    [MaxLength(500)]
    public string? ImagePath { get; set; }

    [Required]
    // nvarchar(max) maps well to string without MaxLength
    public string Description { get; set; } = null!;

    // FK Properties
    public int ManufacturerId { get; set; } // NOT NULL
    public int CategoryId { get; set; }     // NOT NULL

    // smallint maps well to short or int
    public short? UnitsInStock { get; set; } 

    // Navigation Properties
    public Manufacturer Manufacturer { get; set; } = null!;
    public Category Category { get; set; } = null!;
}