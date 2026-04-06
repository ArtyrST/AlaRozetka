using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
