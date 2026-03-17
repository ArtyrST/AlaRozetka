namespace AlaBackEnd.Entity
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }


    }
}
