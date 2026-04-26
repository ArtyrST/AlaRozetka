using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto.UserDto
{
    public class VerifyDto
    {
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
