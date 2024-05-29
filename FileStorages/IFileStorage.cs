namespace Ecommerce.FileStorages;

public interface IFileStorage
{
    Task<string> UploadToRootServerAsync(IFormFile file, params string[] path);
}