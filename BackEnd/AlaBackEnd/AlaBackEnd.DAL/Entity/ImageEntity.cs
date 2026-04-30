using AlaBackEnd.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AlaBackEnd.DAL.Entity
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public bool IsPreview { get; set; }



        //product
        
        public BaseProductEntity? Product { get; set; }
        public int? ProductId { get; set; }

        //user
        public UserEntity? User { get; set; }
        public int? UserId { get; set; } 

    }
}
