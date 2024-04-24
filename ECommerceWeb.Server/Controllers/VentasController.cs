using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using ECommerceWeb.Shared;
using ECommerceWeb.Shared.Request;
using ECommerceWeb.Shared.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentaRepository _repository;
        private readonly ILogger<VentasController> _logger;
        private readonly IClienteRepository _clienteRepository;

        public VentasController(IVentaRepository repository, ILogger<VentasController> logger, IClienteRepository clienteRepository)
        {
            _repository = repository;
            _logger = logger;
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        [Authorize(Roles = Constantes.RolCliente)]
        public async Task<IActionResult> Post(VentaDto request)
        {
            var response = new BaseResponse();

            try
            {
                // Buscamos el ID del cliente basado en el correo electronico.
                var email = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Email).Value;
                var cliente = await _clienteRepository.BuscarPorEmailAsync(email);

                if (cliente is null)
                {
                    response.MensajeError = $"El cliente con el correo {email} no existe!";
                    return BadRequest(response);
                }

                request.ClienteId = cliente.Id;

                var venta = new Venta
                {
                    ClienteId = request.ClienteId,
                    FechaTransaccion = DateTime.Now,
                };

                foreach (var detalleDto in request.VentaDetalles)
                {
                    venta.VentaDetalles.Add(new VentaDetalle
                    {
                        ProductoId = detalleDto.ProductoId,
                        Cantidad = detalleDto.Cantidad,
                        Precio = detalleDto.Precio,
                        Total = detalleDto.Cantidad * detalleDto.Precio
                    });
                }

                venta.Total = venta.VentaDetalles.Sum(p => p.Total);

                await _repository.CrearTransaccionAsync();
                await _repository.AddAsync(venta);
                await _repository.ConfirmarTransaccionAsync();

                _logger.LogInformation("Se creo la venta de forma correcta");

                response.Exito = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.MensajeError = "Error al crear la venta";
                await _repository.ResetearTransaccionAsync();
                _logger.LogCritical(ex, "{MensajeError} {Message}", response.MensajeError, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("dashboard")]
        [Authorize(Roles = Constantes.RolAdministrador)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _repository.MostrarDashboard();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error al mostrar el dashboard {Message}", ex.Message);
                return BadRequest(new
                {
                    MensajeError = "Error al mostrar el dashboard",
                    Exito = false
                });
            }
        }
    }
}
