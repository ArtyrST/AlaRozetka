using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class OrderDto
    {
        public int IdHash { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int VisitersCount { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        
    }
}
