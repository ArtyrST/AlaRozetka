using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class CreateAdditionalServiceDto
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int ProductId { get; set; }
    }
}
