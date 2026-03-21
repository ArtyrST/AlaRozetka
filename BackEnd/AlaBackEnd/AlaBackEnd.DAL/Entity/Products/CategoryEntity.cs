using AlaBackEnd.DAL.Entity.Products;

namespace AlaBackEnd.Entity.Products
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }


        public List<BaseProductEntity> Products { get; set; } = [];
    }
}
