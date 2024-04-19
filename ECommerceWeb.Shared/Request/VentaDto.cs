namespace ECommerceWeb.Shared.Request
{
    public class VentaDto
    {
        public int ClienteId { get; set; }
        public float Total { get; set; }
        public ICollection<VentaDetalleDto> VentaDetalles { get; set; } = new List<VentaDetalleDto>();
    }
}
