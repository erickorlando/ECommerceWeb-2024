using ECommerceWeb.Entities;
using ECommerceWeb.Entities.Infos;

namespace ECommerceWeb.Repositories.Interfaces;

public interface IProductoRepository : IRepositoryBase<Producto>
{
    Task<ICollection<ProductoInfo>> ListarAsync(string? filtro);
}