using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class CreateFeedBackDto
    {
        public int ProductId { get; set; }
        public string Description { get; set; } = string.Empty;
        public float StarCount { get; set; }

    }
}
