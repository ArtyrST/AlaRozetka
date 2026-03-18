namespace AlaBackEnd.Entity
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required CategoryEntity category { get; set; }
    }
}
