using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.BLL.Services.LoginService;
using AlaBackEnd.DAL.Repositories;
using Microsoft.Extensions.Configuration;


namespace AlaBackEnd.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserRepository _user;
        private readonly IConfiguration _config;
        private readonly JwtService _jwt;
        public AuthService(UserRepository user, IConfiguration config, JwtService jwt)
        {
            _user = user;
            _config = config;
            _jwt = jwt;
        }

        public async Task<ServiceResponse> LoginAsync(LoginDto dto)
        {
            var user = await _user.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.PasswordHash, user.Password))
            {
                return ServiceResponse.Error(@$"Користувача з email : {dto.Email} не знайдено");
            }


            return ServiceResponse.Success(@"Успішно!", await _jwt.GenerateTokenAsync(user));

        }

        
    }
}
