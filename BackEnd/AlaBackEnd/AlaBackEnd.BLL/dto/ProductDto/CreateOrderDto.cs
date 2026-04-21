using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class CreateOrderDto
    {
        public int ProductId { get; set; }
        public int VisitorsCount { get; set; }
        public string From {  get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        
    }
}
