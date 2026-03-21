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
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        //relation with category
        public int? CategoryId { get; set; }
        public virtual CategoryEntity? Category { get; set; }

    }
}
