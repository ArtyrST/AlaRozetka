using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using AlaBackEnd.BLL.Services.LoginService;
using AlaBackEnd.DAL.Entity.ProductCart;



namespace AlaBackEnd.BLL.Services
{
    public class UserService 
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _role;
        private readonly PandingUserPerository _panding;
        private readonly EmailVerifService _emailv;
        
        public UserService(EmailVerifService emailv, IMapper mapper, UserRepository userRepository, RoleRepository role, PandingUserPerository panding)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _role = role;
            _panding = panding;
            _emailv = emailv;
        }
        public async Task<ServiceResponse> RegisterUserAsync(PandingUserDto dto)
        {
            if (await _userRepository.IsExistAsync(dto.Email))
            {
                return ServiceResponse.Error($"User with mail: {dto.Email} is already exists");
            }
            dto.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var entity = _mapper.Map<PandingUserEntity>(dto);
            if (entity == null)
            {
                return ServiceResponse.Error("Problem of registration");
            }

            

            bool panding = await _panding.CreateAsync(entity);
            if (!panding)
            {
                return ServiceResponse.Error("Problems...");
            }
            var code = await _emailv.SendOtpAsync(entity.Email);
            return ServiceResponse.Success("Code was sent", null);

        }
        public async Task<ServiceResponse> CreateVerifAsync(VerifyDto dto)
        {
            bool verify = await _emailv.VerifyAsync(dto.Email, dto.Code);
            if (!verify)
            {
                return ServiceResponse.Error("Wrong code");
            }



            var panding = await _panding.GetByEmailAsync(dto.Email);
            if (panding == null)
            {
                return ServiceResponse.Error("User was not found, try again");
            }

            var entity = _mapper.Map<UserEntity>(panding);

            entity.Cart = new CartEntity();

            bool res = await _userRepository.CreateAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Problem with creating user");
            }
            bool panding_delete = await _panding.DeleteEntityAsync(panding);

            return ServiceResponse.Success("Successfuly verificate account", null);

        }
    }
}
