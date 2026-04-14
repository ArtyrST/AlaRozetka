using AlaBackEnd.API.Extensions;
using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlaBackEnd.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _user;
        public UserController(UserService user)
        {
            _user = user;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromForm] RegisterUserDto dto)
        {
            var response = await _user.RegisterUserAsync(dto);
            return this.GetResult(response);
        }

    }
}
