using AlaBackEnd.DAL.Entity;
using AlaBackEnd.DAL.Entity.BaseEntity;
using System.Text.Json.Serialization;

namespace AlaBackEnd.Entity.Products
{
    public class CategoryEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<BaseProductEntity> Products { get; set; } = [];

        //public static CategoryEntity operator =(CategoryEntity c1, CategoryEntity c2)
        //{
        //    return new CategoryEntity (c1.Id = c2.Id, c1.Name = c2.Name);
        //}
    }
}
