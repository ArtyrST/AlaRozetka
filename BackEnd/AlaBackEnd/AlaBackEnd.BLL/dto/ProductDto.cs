

//public int Id { get; set; }
//public required string Name { get; set; } = string.Empty;
//public required double Price { get; set; }
//public required string Country { get; set; } = string.Empty;
//public required string City { get; set; } = string.Empty;
//public required string Descriprion { get; set; } = string.Empty;
//public DateTime Date { get; set; } = DateTime.UtcNow;

using AlaBackEnd.DAL.Entity;
using System.Globalization;

namespace AlaBackEnd.BLL.dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City {  get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<int> Tags { get; set; } = [];
        public List<ImageDto> Images { get; set; } = [];   
        
    }
}
