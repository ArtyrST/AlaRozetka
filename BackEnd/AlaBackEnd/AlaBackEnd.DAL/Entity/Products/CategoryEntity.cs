namespace AlaBackEnd.Entity.Products
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        
        public List<ProductLaptopEntity> Laptops { get; set; } = [];

        public List<ProductMonitorEntity> Monitors { get; set; } = [];
    }
}
