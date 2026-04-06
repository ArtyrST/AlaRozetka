using AlaBackEnd.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        
       
        
        //product
        public bool IsPreview { get; set; }
        public BaseProductEntity? Product { get; set; }
        public int ProductId { get; set; }

    }
}
