using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class CartDto
    {
        public int Id { get; set; }
        public List<OrderDto> Orders { get; set; } = [];
    }
}
