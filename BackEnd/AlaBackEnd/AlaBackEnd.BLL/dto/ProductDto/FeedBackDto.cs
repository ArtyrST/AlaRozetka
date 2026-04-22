using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class FeedBackDto
    {
        public string Description { get; set; } = string.Empty;
        public float StartCounter { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
