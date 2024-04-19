namespace ECommerceWeb.Shared.Request
{
    public class VentaDetalleDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Total { get; set; }
    }
}