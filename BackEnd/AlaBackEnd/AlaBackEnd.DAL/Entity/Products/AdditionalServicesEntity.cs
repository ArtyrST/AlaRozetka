using AlaBackEnd.DAL.Entity.BaseEntity;
using AlaBackEnd.DAL.Entity.ProductCart;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.Products
{
    public class AdditionalServicesEntity : IBaseEntity
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public List<BaseProductEntity> Products { get; set; } = [];
        public List<OrderItemEntity> Services { get; set; } = []; 

    }
}
