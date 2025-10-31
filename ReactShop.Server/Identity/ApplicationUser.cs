using Microsoft.AspNetCore.Identity;
using ReactShop.Server.Domain.Entities;

namespace ReactShop.Server.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName  { get; set; }
    //Email is inherited from 'IdentityUser'
    
    // Inverse Navigation für die 1:1-Beziehung
    public CustomerProfile? CustomerProfile { get; set; }
}