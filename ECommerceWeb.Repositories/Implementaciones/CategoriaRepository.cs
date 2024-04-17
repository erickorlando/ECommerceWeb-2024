using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;

namespace ECommerceWeb.Repositories.Implementaciones;

public class CategoriaRepository(ECommerceDbContext context) : 
    RepositoryBase<Categoria>(context), ICategoriaRepository;