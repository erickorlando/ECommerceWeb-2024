using ECommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWeb.DataAccess.Configurations;

public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
{
    public void Configure(EntityTypeBuilder<Marca> builder)
    {
        var lista = new List<Marca>
        {
            new() { Id = 1, Nombre = "Samsung" },
            new() { Id = 2, Nombre = "Apple" },
            new() { Id = 3, Nombre = "Xiaomi" },
            new() { Id = 4, Nombre = "LG" },
            new() { Id = 5, Nombre = "Sony" },
            new() { Id = 6, Nombre = "Honor" },
            new() { Id = 7, Nombre = "Oppo" },
        };

        builder.HasData(lista);
    }
}