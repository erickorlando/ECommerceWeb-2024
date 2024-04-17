namespace ECommerceWeb.Shared.Response;

public class LoginDtoResponse : BaseResponse
{
    public string Token { get; set; } = default!;
    public string NombreCompleto { get; set; } = default!;
    public List<string> Roles { get; set; } = default!;
}