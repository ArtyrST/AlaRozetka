using AlaBackEnd.DAL.Entity.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.dto.UserDto
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Description {  get; set; } = string.Empty;
        public IFormFile? Avatar { get; set; }
        public GenderEnum? Gender { get; set; }
    }
}
