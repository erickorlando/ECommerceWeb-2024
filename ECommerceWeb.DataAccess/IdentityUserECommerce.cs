using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ECommerceWeb.DataAccess;

public class IdentityUserECommerce : IdentityUser
{
    [StringLength(200)]
    public string NombreCompleto { get; set; } = default!;

    public DateTime FechaNacimiento { get; set; }

    [StringLength(250)]
    public string? Direccion { get; set; }
}