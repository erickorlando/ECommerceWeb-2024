namespace ECommerceWeb.Shared.Response;

public class ProductoDtoResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string Descripcion { get; set; } = default!;
    public float PrecioUnitario { get; set; }
    public string Marca { get; set; } = default!;
    public string Categoria { get; set; } = default!;
    public int CategoriaId { get; set; }
    public string? UrlImagen { get; set; }
}