using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;


namespace AlaBackEnd.BLL.Services.ImagesService
{
    // AlaBackEnd.BLL/Services/ImageService.cs
    public class ImageService : IImageInterface
    {
        private readonly string _basePath;
        private readonly IMapper _mapper; 

        public ImageService(IWebHostEnvironment env, IMapper mapper)
        {
            _basePath = Path.Combine(env.ContentRootPath, "Uploads", "Images");
            Directory.CreateDirectory(_basePath); 
            _mapper = mapper;
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
