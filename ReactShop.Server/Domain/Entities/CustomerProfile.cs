using System.ComponentModel.DataAnnotations;
using ReactShop.Server.Identity;

namespace ReactShop.Server.Domain.Entities;

public class CustomerProfile
{
    [Key]
    public int Id { get; set; }

    // FK to AspNetUsers
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;

    [MaxLength(200)]
    public string? DisplayName { get; set; }
    public int? Age { get; set; }
    public string? AddressLine1 { get; set; }
    [MaxLength(100)]
    public string? City { get; set; }
    [MaxLength(100)]
    public string? Country { get; set; }
}