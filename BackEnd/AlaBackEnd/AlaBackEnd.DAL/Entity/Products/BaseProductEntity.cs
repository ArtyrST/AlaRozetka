
using AlaBackEnd.DAL.Entity.BaseEntity;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Entity.Users;
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
        public required string Descriprion {  get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        //tags
        public required List<ProductTagEntity> Tags { get; set; } = [];
        //relation with category
        public required int? CategoryId { get; set; }
        public required string CategoryName { get; set; } = string.Empty;
        public virtual CategoryEntity? Category { get; set; }
        //user realtor
        public required int? UserId { get; set; }
        public UserEntity? User { get; set; } 


        //with orderItem
       
        

    }
}
