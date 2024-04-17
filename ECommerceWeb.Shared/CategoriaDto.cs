namespace ECommerceWeb.Shared
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string? Comentarios { get; set; }
    }
}
