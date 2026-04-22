using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.DAL.Entity.BaseEntity;


namespace AlaBackEnd.DAL.Entity
{
    public class FeedBackEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public float StarCount { get; set; }

        //user
        public UserEntity? User { get; set; }
        public int UserId { get; set; }

        //with product
        public BaseProductEntity? Product { get; set; }
        public int ProductId { get; set; }
    }
}
