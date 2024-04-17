using ECommerceWeb.Shared.Request;
using ECommerceWeb.Shared.Response;

namespace ECommerceWeb.Server.Services;

public interface IUserService
{
    Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request);

    Task<BaseResponse> RegisterAsync(RegistrarUsuarioDto request);
}