using ECommerceWeb.Server.Services;
using ECommerceWeb.Shared.Request;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUserService _service;

        public UsuariosController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDtoRequest request)
        {
            var response = await _service.LoginAsync(request);

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrarUsuarioDto request)
        {
            var response = await _service.RegisterAsync(request);

            return Ok(response);
        }
    }
}
