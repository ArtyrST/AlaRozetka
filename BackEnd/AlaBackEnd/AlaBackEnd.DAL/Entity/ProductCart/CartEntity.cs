
using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.DAL.Entity.BaseEntity;

namespace AlaBackEnd.DAL.Entity.ProductCart
{
    public class CartEntity : IBaseEntity
    {
        public int Id { get; set; }

        public List<OrderItemEntity> OrderItems { get; set; } = [];

        public UserEntity? User { get; set; }
        public int UserId { get; set; }
    }
}
