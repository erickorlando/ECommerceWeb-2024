using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Entities.Infos;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Repositories.Implementaciones;

public class ProductoRepository : RepositoryBase<Producto>, IProductoRepository
{
    public ProductoRepository(ECommerceDbContext context)
        : base(context)
    {
    }

    public async Task<ICollection<ProductoInfo>> ListarAsync(string? filtro)
    {
        var productos = Context.Set<Producto>()
            .Where(p => p.Estado)
            .AsQueryable();

        if (filtro is not null)
        {
            productos = productos.Where(p => p.Nombre.Contains(filtro));
        }

        return await productos
            .Select(x => new ProductoInfo
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Categoria = x.Categoria.Nombre,
                CategoriaId = x.CategoriaId,
                Marca = x.Marca.Nombre,
                PrecioUnitario = x.PrecioUnitario,
                UrlImagen = x.UrlImagen 
            })
            .AsNoTracking()
            .ToListAsync();
    }
}