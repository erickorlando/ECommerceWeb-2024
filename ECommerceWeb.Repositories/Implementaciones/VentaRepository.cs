using System.Data;
using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Repositories.Implementaciones;

public class VentaRepository : RepositoryBase<Venta>, IVentaRepository
{
    public VentaRepository(ECommerceDbContext context) 
        : base(context)
    {
    }

    public override async Task AddAsync(Venta entity)
    {
        await Context.AddAsync(entity);
    }

    public async Task CrearTransaccionAsync()
    {
        await Context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
    }

    public async Task ConfirmarTransaccionAsync()
    {
        await Context.Database.CommitTransactionAsync();
        await Context.SaveChangesAsync();
    }

    public async Task ResetearTransaccionAsync()
    {
        await Context.Database.RollbackTransactionAsync();
    }

    public async Task<Dashboard> MostrarDashboard()
    {
        var entity = Context.Database.SqlQuery<Dashboard>($"EXEC dbo.uspDashboard");
        return await Task.FromResult(entity.AsEnumerable().First());
    }
}