using AlaBackEnd.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity
{
    public class FeedBackEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int StarCount { get; set; }

        //user
        public UserEntity? User { get; set; }
        public int UserId { get; set; }

        //with product
        public BaseProductEntity? Product { get; set; }
        public int ProductId { get; set; }
    }
}
