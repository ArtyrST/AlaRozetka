using System;
using System.Collections.Generic;
using System.Text;

//public int Id { get; set; }
//public required string Name { get; set; } = string.Empty;
//public required double Price { get; set; }
//public required string Country { get; set; } = string.Empty;
//public required string City { get; set; } = string.Empty;
//public required string Descriprion { get; set; } = string.Empty;
//public DateTime Date { get; set; } = DateTime.UtcNow;

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
        public List<int> Tags { get; set; } = [];
        public string Image { get; set; } = string.Empty;
    }
}
