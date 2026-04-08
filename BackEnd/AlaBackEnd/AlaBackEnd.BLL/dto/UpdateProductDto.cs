using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        
        public double Price { get; set; }
        
        public string Country { get; set; } = string.Empty;
        
        public string City { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
    }
}
