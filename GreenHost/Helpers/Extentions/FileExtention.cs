using Microsoft.AspNetCore.Hosting;

namespace GreenHost.Helpers.Extentions;

public static class FileExtention
{

    public static string CreateFile(this IFormFile file, string webRootPath, string folderName)
    {
        string fileName = Guid.NewGuid().ToString() + file.FileName;
        string path = Path.Combine(webRootPath, folderName);
        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileName;
    }

    public static void RemoveFile(string webRootPath, string folderName, string fileName)
    {
        string ExitingFile = Path.Combine(webRootPath, folderName, fileName);
        if (File.Exists(ExitingFile)) System.IO.File.Delete(ExitingFile);
    }

    public static string UpdateFile(this IFormFile file, string webRootPath, string folderName, string oldUrl)
    {
        RemoveFile(webRootPath,folderName,file.FileName);
        var newImageUrl = file.CreateFile(webRootPath, folderName);
        return newImageUrl;
    }

    public static bool IsValidFile(this IFormFile file)
    {
        if (file is null) return false;
        if (!file.ContentType.Contains("image")) return false;
        if (file.Length > 2000000) return false;

        return true;
    }
}
