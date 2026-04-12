
using AlaBackEnd.DAL.Entity.BaseEntity;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.Entity.Products;


namespace AlaBackEnd.DAL.Entity
{
    public class BaseProductEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        //tags
        public List<ProductTagEntity> Tags { get; set; } = [];
        //relation with category
        public int? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        //user realtor
        public int? UserId { get; set; }
        public UserEntity? User { get; set; }


        //with image
        public ICollection<ImageEntity> Images { get; set; } = [];

        //with feedbacks
        public List<FeedBackEntity> Feedbacks { get; set; } = [];
       
        
        

    }
}
