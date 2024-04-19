using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Shared.Request;

public class ProductoDtoRequest
{
    public int Id { get; set; }
  
    [Required(ErrorMessage = Constantes.CampoRequerido)]
    [MaxLength(50)]
    public string Nombre { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Descripcion { get; set; } = default!;

    [Range(1, 9999, ErrorMessage = Constantes.ValidacionRango)]
    [Display(Name = "Precio Unitario")]
    public float PrecioUnitario { get; set; }

    public int MarcaId { get; set; }
    public int CategoriaId { get; set; }

    public string? UrlImagen { get; set; }

    public string? Base64Imagen { get; set; }
    public string? NombreArchivo { get; set; }
}