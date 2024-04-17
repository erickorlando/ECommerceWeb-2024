using ECommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWeb.DataAccess.Configurations;

public class TipoClienteConfiguration : IEntityTypeConfiguration<TipoCliente>
{
    public void Configure(EntityTypeBuilder<TipoCliente> builder)
    {
        var lista = new List<TipoCliente>
        {
            new() { Id = 1, Descripcion = "Cliente Normal" },
            new() { Id = 2, Descripcion = "Cliente Especial" },
        };

        builder.HasData(lista);
    }
}