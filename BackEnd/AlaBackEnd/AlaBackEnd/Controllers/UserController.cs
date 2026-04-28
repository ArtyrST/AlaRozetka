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
        private readonly IRieltorAcceptService _request;
        public UserController(UserService user, IAuthService authService, IProductCartInterface cart, IRieltorAcceptService request)
        {
            _user = user;
            _authService = authService;
            _cart = cart;
            _request = request;
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
        [Authorize(Roles = "Admin")]
        [HttpGet("get-requests")]
        public async Task<IActionResult> GetAllRequestsAsync()
        {
            var response = await _request.GetAllRequests();
            return this.GetResult(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("make-choise-rieltor-role")]
        public async Task<IActionResult> ChoiseRieltorRoleRequestAsync(AcceptRieltorRoleDto dto)
        {
            var response = await _request.CreateChoiseAsync(dto);
            return this.GetResult(response);
        }
        [Authorize(Roles = "Guest")]
        [HttpPost("create-rieltor-request")]
        public async Task<IActionResult> CreateRieltorRequestAsync([FromForm] RieltorRequestsDto dto)
        {
            var response = await _request.CreateRequest(dto);
            return this.GetResult(response);
        }

    }
}
