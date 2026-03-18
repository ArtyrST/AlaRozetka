namespace AlaBackEnd.Entity
{
    public class ProductLaptopEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public int Ram { get; set; }
        public string? DdrSeries { get; set; }
        public string? Cpu  { get; set; }



    }
}
