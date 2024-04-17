namespace ECommerceWeb.Entities;

public class VentaDetalle : EntityBase
{
    public Venta Venta { get; set; } = default!;
    public int VentaId { get; set; }

    public Producto Producto { get; set; } = default!;
    public int ProductoId { get; set; }

    public float Precio { get; set; }
    public int Cantidad { get; set; }
    public float Total { get; set; }
}