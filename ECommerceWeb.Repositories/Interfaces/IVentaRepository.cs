using ECommerceWeb.Entities;

namespace ECommerceWeb.Repositories.Interfaces;

public interface IVentaRepository : IRepositoryBase<Venta>
{
    Task CrearTransaccionAsync();

    Task ConfirmarTransaccionAsync();

    Task ResetearTransaccionAsync();

    Task<Dashboard> MostrarDashboard();
}