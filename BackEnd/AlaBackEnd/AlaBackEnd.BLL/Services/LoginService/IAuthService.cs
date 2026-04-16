using AlaBackEnd.BLL.dto.UserDto;


namespace AlaBackEnd.BLL.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse> LoginAsync(LoginDto dto); 
    }
}
