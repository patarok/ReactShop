using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ReactShop.Server.Identity;

namespace ReactShop.Server.Domain.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    // Remove this legacy field from MVC-era Customer table
    // public int CustomerId { get; set; }

    // Foreign key to Identity user (AspNetUsers.Id is string)
    [Required]
    public string UserId { get; set; } = null!;

    // Navigation to the principal (Identity user)
    public ApplicationUser User { get; set; } = null!;

    public decimal PriceTotal { get; set; }
    public DateTimeOffset? DateOrdered { get; set; }
    public DateTimeOffset? DatePaid { get; set; }

    [MaxLength(150), Required]
    public string FirstName { get; set; } = null!;
    [MaxLength(150), Required]
    public string LastName { get; set; } = null!;
    [MaxLength(150), Required]
    public string Street { get; set; } = null!;
    [MaxLength(50), Required]
    public string ZipCode { get; set; } = null!;
    [MaxLength(200), Required]
    public string City { get; set; } = null!;

    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}