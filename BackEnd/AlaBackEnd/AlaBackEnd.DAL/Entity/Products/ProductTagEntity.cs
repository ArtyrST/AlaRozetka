using AlaBackEnd.DAL.Entity.BaseEntity;
using System.Text.Json.Serialization;

namespace AlaBackEnd.DAL.Entity.Products
{
    public class ProductTagEntity : IBaseEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<BaseProductEntity> Products { get; set; } = [];

    }
}
