using AlaBackEnd.DAL.Entity.Products;

namespace AlaBackEnd.Entity.Products
{
    public class ProductLaptopEntity : BaseProductEntity
    {
        
        public required string Brand { get; set; }
        public int Ram { get; set; }
        public int Memory { get; set; }
        public string? DdrSeries { get; set; }
        public string? Cpu  { get; set; }
        public string? Disk { get; set; }

        



    }
}
