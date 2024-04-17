using ECommerceWeb.Entities;

namespace ECommerceWeb.Repositories.Interfaces;

public interface IClienteRepository : IRepositoryBase<Cliente>
{
    Task<Cliente?> BuscarPorEmailAsync(string email);
}