using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Für [NotMapped]

namespace ReactShop.Server.Domain.Entities;

public class OrderLine
{
    [Key]
    public int Id { get; set; } // IDENTITY(1,1)

    // FK Properties
    public int OrderId { get; set; } // NOT NULL
    public int ProductId { get; set; } // NOT NULL

    public int Amount { get; set; } // NOT NULL

    // decimal(19, 2)
    public decimal NetUnitPrice { get; set; }

    // decimal(9, 2)
    public decimal TaxRate { get; set; }

    // Navigation Properties
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;

    // 💡 Berechnete Eigenschaften (aus dem Partial Class Snippet)
    // [NotMapped] stellt sicher, dass diese nicht als Spalten in der DB erstellt werden.
    [NotMapped]
    public decimal GrossUnitPrice => NetUnitPrice * (1 + TaxRate / 100);

    [NotMapped]
    public decimal LinePrice => GrossUnitPrice * Amount;
}