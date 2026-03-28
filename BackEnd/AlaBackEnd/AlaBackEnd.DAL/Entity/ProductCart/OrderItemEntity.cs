using AlaBackEnd.DAL.Entity.ProductCart;
using AlaBackEnd.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.ProductCart
{
    public class OrderItemEntity
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        
        //with cart
        public int CartId { get; set; }
        public CartEntity? Cart { get; set; }


        //with product
        public BaseProductEntity? Product { get; set; }
        public int ProductId { get; set; }
        
        

              
        

    }
}
