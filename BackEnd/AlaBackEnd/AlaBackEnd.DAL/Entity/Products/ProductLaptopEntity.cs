namespace AlaBackEnd.Entity.Products
{
    public class ProductLaptopEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public required string Brand { get; set; }
        public int Ram { get; set; }
        public int Memory { get; set; }
        public string? DdrSeries { get; set; }
        public string? Cpu  { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        //relation with category
        public int? CategoryId { get; set; }
        public virtual CategoryEntity? Category { get; set; }



    }
}
