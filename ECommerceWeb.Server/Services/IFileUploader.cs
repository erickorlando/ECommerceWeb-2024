namespace ECommerceWeb.Server.Services;

public interface IFileUploader
{
    Task<string> UploadFileAsync(string? base64Imagen, string? archivo);
}