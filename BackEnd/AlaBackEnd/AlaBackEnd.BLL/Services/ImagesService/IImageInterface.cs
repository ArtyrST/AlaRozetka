using AlaBackEnd.DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.Services.ImagesService
{
    public interface IImageInterface
    {
        Task<string> SaveImageAsync(IFormFile file, string path);
        public bool DeleteImage(string path);
        
    }
}
