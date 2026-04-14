using AlaBackEnd.DAL.Entity.BaseEntity;
using AlaBackEnd.DAL.Entity.ProductCart;


namespace AlaBackEnd.DAL.Entity.Users
{
    public class UserEntity : IBaseEntity
    {
        public int Id { get;set; }
        public required string Email { get;set; }  
        public required string FirstName { get;set; } 
        public required string SecondName { get;set; }
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        //Relation with role
        public virtual List<RoleEntity> Roles { get; set; } = [];
        //Relation with cart
        public CartEntity? Cart { get; set; }
        // with product
        public List<BaseProductEntity> Products { get; set; } = [];

        //with feedback
        public List<FeedBackEntity> FeedBacks { get; set; } = [];
    }
}
