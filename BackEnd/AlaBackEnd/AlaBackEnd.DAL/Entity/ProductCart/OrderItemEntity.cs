
using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.DAL.Entity.BaseEntity;
using AlaBackEnd.DAL.Entity.Products;

namespace AlaBackEnd.DAL.Entity.ProductCart
{
    public class OrderItemEntity : IBaseEntity
    {
        public int Id { get; set; }
        
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public int VisitorsCount { get; set; }
        
        //with cart
        public int CartId { get; set; }
        public CartEntity? Cart { get; set; }


        //with product
        public BaseProductEntity? Product { get; set; }
        public int ProductId { get; set; }

        //with user
        public UserEntity? Rieltor { get; set; }
        public int? RieltorId { get; set; }

        //with AdditionalServices
        public List<AdditionalServicesEntity> AdditionalServices { get; set; } = [];

              
        

    }
}
