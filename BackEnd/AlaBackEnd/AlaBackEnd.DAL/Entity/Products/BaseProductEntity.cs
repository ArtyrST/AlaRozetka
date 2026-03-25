using AlaBackEnd.DAL.Entity.ProductCart;
using AlaBackEnd.Entity.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.Products
{
    public class BaseProductEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required double Price { get; set; }
        public required string Country { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        //relation with category
        public required int? CategoryId { get; set; }
        public required string CategoryName { get; set; } = string.Empty;
        public virtual CategoryEntity? Category { get; set; }

        //with orderItem
       
        

    }
}
