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
        
        public string? Country { get; set; }
        
        public string? City { get; set; } 
        
        public string? Description { get; set; }
        public string? UpdateDateFrom { get; set; } = string.Empty;
        
        public string? UpdateDateTo { get; set; } = string.Empty;
        public List<int> Tags { get; set; } = [];
        public IFormFile? Image { get; set; }
    }
}
