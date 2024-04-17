using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Repositories.Implementaciones;

public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
{
    public ClienteRepository(ECommerceDbContext context) 
        : base(context)
    {
    }

    public async Task<Cliente?> BuscarPorEmailAsync(string email)
    {
        return await Context.Set<Cliente>()
            .FirstOrDefaultAsync(o => o.Email == email);
    }
}