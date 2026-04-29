using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class GetAdditionalServicesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
