
using AlaBackEnd.DAL.Entity.BaseEntity;
using AlaBackEnd.Entity.Products;


namespace AlaBackEnd.DAL.Entity
{
    public class BaseProductEntity : IBaseEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required double Price { get; set; }
        public required string Country { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        //relation with category
        public required int? CategoryId { get; set; }
        public required string CategoryName { get; set; } = string.Empty;
        public virtual CategoryEntity? Category { get; set; }

        //with orderItem
       
        

    }
}
