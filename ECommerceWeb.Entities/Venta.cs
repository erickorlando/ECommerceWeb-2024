namespace ECommerceWeb.Entities;

public class Venta : EntityBase
{
    public Cliente Cliente { get; set; } = default!;
    public int ClienteId { get; set; }
    public float Total { get; set; }
    public DateTime FechaTransaccion { get; set; }
    
    //Esto es una propiedad de navegacion
    public ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();

    public Venta()
    {
        FechaTransaccion = DateTime.Now;
    }
}