using Azure.Storage.Blobs;

namespace ECommerceWeb.Server.Services
{
    public class AzureFileUploader : IFileUploader
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AzureFileUploader> _logger;

        public AzureFileUploader(IConfiguration configuration, ILogger<AzureFileUploader> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<string> UploadFileAsync(string? base64Imagen, string? archivo)
        {
            if (string.IsNullOrWhiteSpace(base64Imagen) || string.IsNullOrWhiteSpace(archivo))
            {
                return string.Empty;
            }

            try
            {
                var client = new BlobServiceClient(_configuration.GetValue<string>("Hosting:ConnectionString"));
                var container = client.GetBlobContainerClient("imagenes");

                var blob = container.GetBlobClient(archivo);

                await using var stream = new MemoryStream(Convert.FromBase64String(base64Imagen));
                await blob.UploadAsync(stream, overwrite: true);

                _logger.LogInformation("Se subio la imagen a Azure Blob Storage");

                return $"{_configuration.GetValue<string>("Hosting:BaseUrl")}/{archivo}";
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error al subir el archivo en Azure {archivo}", archivo);
                return string.Empty;
            }
        }
    }
}
