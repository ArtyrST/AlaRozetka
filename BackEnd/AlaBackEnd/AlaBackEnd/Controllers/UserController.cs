using AlaBackEnd.API.Extensions;
using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.BLL.Services;
using AlaBackEnd.BLL.Services.Interfaces;
using AlaBackEnd.BLL.Services.LoginService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlaBackEnd.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _user;
        private readonly IAuthService _authService;
        private readonly IProductCartInterface _cart;
        public UserController(UserService user, IAuthService authService, IProductCartInterface cart)
        {
            _user = user;
            _authService = authService;
            _cart = cart;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromForm] PandingUserDto dto)
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
        [HttpPost("verification")]
        public async Task<IActionResult> EmailVerifAsync([FromForm]VerifyDto dto)
        {
            var response = await _user.CreateVerifAsync(dto);

            return this.GetResult(response);        
        }
        [Authorize(Roles = "Guest")]
        [HttpGet("get-cart")]
        public async Task<IActionResult> GetCartAsync()
        {
            var response = await _cart.GetUserCartAsync();
            return this.GetResult(response);
        }

    }
}
