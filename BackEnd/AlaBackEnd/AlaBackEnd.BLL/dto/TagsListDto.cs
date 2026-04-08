using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlaBackEnd.BLL.dto
{
    public class TagsListDto
    {
        public int id {  get; set; }
        [Required]
        public List<int> TagsId { get; set; } = [];
        
    }
}
