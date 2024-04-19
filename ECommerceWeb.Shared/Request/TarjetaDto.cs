using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Shared.Request
{
    public class TarjetaDto
    {
        [Required(ErrorMessage = "Ingrese Titular")]
        public string? Titular { get; set; }

        [Required]
        public string? Numero { get; set; }

        [Required]
        public string? Vigencia { get; set; }

        [Required]
        public string? Cvv { get; set; }
    }
}
