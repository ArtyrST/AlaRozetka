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
        private readonly IAuthService _authService;
        public UserController(UserService user, IAuthService authService)
        {
            _user = user;
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromForm] RegisterUserDto dto)
        {
            var response = await _user.RegisterUserAsync(dto);
            return this.GetResult(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromForm] LoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);
            return this.GetResult(response);
        }

    }
}
