using AlaBackEnd.DAL.Entity.Products;
using System.Text.Json.Serialization;

namespace AlaBackEnd.Entity.Products
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        [JsonIgnore]
        public List<BaseProductEntity> Products { get; set; } = [];
    }
}
