using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlaBackEnd.BLL.dto
{
    public class CreateProductDto
    {
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = string.Empty;
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [FromForm]
        public List<int> Tags { get; set; } = [];
        
        [FromForm]
        public IFormFileCollection? Images { get; set; }
        public int PreviewImageId { get; set; }
    }
}
