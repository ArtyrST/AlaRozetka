using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.Services.LoginService
{
    public class PandingUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
