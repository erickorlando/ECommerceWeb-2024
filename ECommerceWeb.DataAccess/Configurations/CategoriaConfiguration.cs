using ECommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWeb.DataAccess.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        // Data Seeding.

        var lista = new List<Categoria>
        {
            new() { Id = 1, Nombre = "Celulares" },
            new() { Id = 2, Nombre = "Televisores" },
            new() { Id = 3, Nombre = "Computadoras" },
        };

        builder.HasData(lista);
    }
}