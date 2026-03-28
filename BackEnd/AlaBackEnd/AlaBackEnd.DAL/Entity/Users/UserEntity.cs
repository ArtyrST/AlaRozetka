using AlaBackEnd.DAL.Entity.ProductCart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlaBackEnd.DAL.Entity.Users
{
    public class UserEntity 
    {
        public int Id { get;set; }
        public required string Email { get;set; }  
        public required string FirstName { get;set; } 
        public required string SecondName { get;set; }
        public string LastName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public bool IsGuest { get; set; } = true;
        public bool IsRieltor { get; set; }

        //Relation with role
        public virtual List<RoleEntity> Roles { get; set; } = [];
        //Relation with cart
        public CartEntity? Cart { get; set; }
        // with product
        public List<BaseProductEntity> Products { get; set; } = [];
    }
}
