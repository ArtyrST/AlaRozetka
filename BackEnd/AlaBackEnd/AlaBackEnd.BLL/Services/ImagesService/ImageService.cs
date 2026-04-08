using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace AlaBackEnd.BLL.Services.ImagesService
{
    // AlaBackEnd.BLL/Services/ImageService.cs
    public class ImageService : IImageInterface
    {
        private readonly string _basePath;

        public ImageService(IWebHostEnvironment env)
        {
            _basePath = Path.Combine(env.ContentRootPath, "Uploads", "Images");
            Directory.CreateDirectory(_basePath); 
        }

        public async Task<string> SaveImageAsync(IFormFile file, string path)
        {
            

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(_basePath, fileName);

            

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            
            return fileName;
        }
        public bool DeleteImage(string path)
        {
            var fullPath = Path.Combine(_basePath, path);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
        }
    }
}
