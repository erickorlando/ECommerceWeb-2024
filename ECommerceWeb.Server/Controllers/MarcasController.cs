using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarcasController : ControllerBase
{
    private readonly IMarcaRepository _repository;

    public MarcasController(IMarcaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _repository.ListAsync());
    }
}