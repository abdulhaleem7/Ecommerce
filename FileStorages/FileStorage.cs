using System.Text.RegularExpressions;

namespace Ecommerce.FileStorages;

public class FileStorage(IWebHostEnvironment webHostEnvironment) : IFileStorage
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
    public async Task<string> UploadToRootServerAsync(IFormFile file, params string[] path)
    {
        var subPath = "";
        if (path is not null)
            subPath = Path.Combine(path);

        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, subPath);

        if (file is null || filePath is null || file.Length is 0)
            return null;

        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);

        var fileName = GenerateFileName(file.FileName);
        var fullPath = Path.Combine(filePath, fileName);
        using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream);
        return fileName;
    }
    public string GenerateFileName(string sourceFileName)
    {
        var fileExtension = Path.GetExtension(sourceFileName);
        sourceFileName = sourceFileName.Length <= 10 ? sourceFileName : sourceFileName[..10];
        var fileName = $"{sourceFileName}{Guid.NewGuid().ToString()[..25]}{fileExtension}";
        return RemoveSpecialCharacters(fileName);
    }
    
    public static string RemoveSpecialCharacters(string str) => Regex.Replace(str, "[^a-zA-Z0-9_.]+", string.Empty, RegexOptions.Compiled);
}