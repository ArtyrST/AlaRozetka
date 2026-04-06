using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class CreateProductDto
    {
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
    }
}
