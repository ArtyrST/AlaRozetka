using System;
using System.Collections.Generic;
using System.Text;
using AlaBackEnd.DAL.Entity.Users;

namespace AlaBackEnd.DAL.Entity.ProductCart
{
    public class CartEntity
    {
        public int Id { get; set; }

        public List<OrderItemEntity> OrderItems { get; set; } = [];

        public UserEntity? User { get; set; }
        public int UserId { get; set; }
    }
}
