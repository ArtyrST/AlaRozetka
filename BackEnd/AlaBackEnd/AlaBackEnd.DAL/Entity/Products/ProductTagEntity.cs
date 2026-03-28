using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AlaBackEnd.DAL.Entity.Products
{
    public class ProductTagEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public required List<BaseProductEntity> Products { get; set; } = [];

    }
}
