using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlaBackEnd.BLL.dto.UserDto
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Будь ласка, введіть коректну електронну адресу.")]
        public string Email { get; set; } = string.Empty;

        public string SecondName { get; set; } = string.Empty;
        
        public string Login { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        //public List<int> Roles { get; set; } = [];

    }
}
