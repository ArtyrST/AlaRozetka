using AlaBackEnd.DAL.Entity.Products;

namespace AlaBackEnd.Entity.Products
{
    public class ProductMonitorEntity : BaseProductEntity
    {
        
        
        public float Resolution { get; set; }
        public string MatrixType { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;

        
    }
}
