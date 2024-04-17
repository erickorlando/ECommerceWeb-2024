namespace ECommerceWeb.Entities;

public class Cliente : EntityBase
{
    public string Nombres { get; set; } = default!;
    public string Apellidos { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime FechaNacimiento { get; set; }
    public TipoCliente TipoCliente { get; set; } = default!;
    public int TipoClienteId { get; set; }
}