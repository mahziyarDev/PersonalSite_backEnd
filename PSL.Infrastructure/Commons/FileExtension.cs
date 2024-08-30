using Microsoft.AspNetCore.Http;

namespace PSL.Infrastructure.Commons;

public static class FileExtension
{
    public static string FileSave(this IFormFile file,Guid name)
    {
        var addressFile = "wwwroot/ContentFiles/";
        if (!Directory.Exists(addressFile))
        {
            Directory.CreateDirectory(addressFile);
        }
        var extention = Path.GetExtension(file.FileName);
        
        var fullPath = Path.Combine(addressFile,name+extention);
        
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
             file.CopyTo(stream);
        }

        return fullPath;
    }
    

   
}
