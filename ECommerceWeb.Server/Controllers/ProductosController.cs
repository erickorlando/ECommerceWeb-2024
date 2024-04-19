using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using ECommerceWeb.Server.Services;
using ECommerceWeb.Shared.Request;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoRepository _repository;
    private readonly IFileUploader _fileUploader;

    public ProductosController(IProductoRepository repository, IFileUploader fileUploader)
    {
        _repository = repository;
        _fileUploader = fileUploader;
    }

    // GET: api/productos
    // GET: api/productos?filtro=string
    [HttpGet]
    public async Task<IActionResult> Get(string? filtro)
    {
        return Ok(await _repository.ListarAsync(filtro));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var registro = await _repository.FindAsync(id);
        if (registro is null)
        {
            return NotFound();
        }

        var response = new ProductoDtoRequest
        {
            Id = registro.Id,
            Nombre = registro.Nombre,
            Descripcion = registro.Descripcion,
            PrecioUnitario = registro.PrecioUnitario,
            CategoriaId = registro.CategoriaId,
            MarcaId = registro.MarcaId,
            UrlImagen = registro.UrlImagen
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductoDtoRequest request)
    {
        var producto = new Producto
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            PrecioUnitario = request.PrecioUnitario,
            MarcaId = request.MarcaId,
            CategoriaId = request.CategoriaId
        };

        producto.UrlImagen = await _fileUploader.UploadFileAsync(request.Base64Imagen, request.NombreArchivo);

        await _repository.AddAsync(producto);

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, ProductoDtoRequest request)
    {
        var registro = await _repository.FindAsync(id);
        if (registro is null)
        {
            return NotFound();
        }

        registro.Nombre = request.Nombre;
        registro.Descripcion = request.Descripcion;
        registro.PrecioUnitario = request.PrecioUnitario;
        registro.MarcaId = request.MarcaId;
        registro.CategoriaId = request.CategoriaId;

        if (!string.IsNullOrWhiteSpace(request.Base64Imagen))
        {
            registro.UrlImagen = await _fileUploader.UploadFileAsync(request.Base64Imagen, request.NombreArchivo);
        }

        await _repository.UpdateAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return Ok();
    }
}