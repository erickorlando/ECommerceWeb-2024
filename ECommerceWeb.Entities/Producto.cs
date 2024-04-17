namespace ECommerceWeb.Entities;

public class Producto : EntityBase
{
    public string Nombre { get; set; } = default!;
    public string Descripcion { get; set; } = default!;
    public float PrecioUnitario { get; set; }
    public string? UrlImagen { get; set; }
    public Categoria Categoria { get; set; } = default!;
    public int CategoriaId { get; set; }
    public Marca Marca { get; set; } = default!;
    public int MarcaId { get; set; }
}