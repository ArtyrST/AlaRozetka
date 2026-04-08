using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class ImageDto
    {
        public int id {  get; set; }
        public string Path { get; set; } = string.Empty;    
        public bool IsPreview { get; set; } 
    }
}
