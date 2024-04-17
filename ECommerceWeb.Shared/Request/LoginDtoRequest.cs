namespace ECommerceWeb.Shared.Request;

public class LoginDtoRequest
{
    public string Usuario { get; set; } = default!;
    public string Password { get; set; } = default!;
}