namespace AlaBackEnd.Entity.Products
{
    public class ProductMonitorEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public float Resolution { get; set; }
        public string MatrixType { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;

        //relation with category
        public int? CategoryId { get; set; }
        public virtual CategoryEntity? Category { get; set; }

    }
}
