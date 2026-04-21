using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
using AlaBackEnd.DAL.Entity.ProductCart;


namespace AlaBackEnd.BLL.Services
{
    public class UserService 
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _role;
        
        public UserService(IMapper mapper, UserRepository userRepository, RoleRepository role)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _role = role;
            
        }
        public async Task<ServiceResponse> RegisterUserAsync(RegisterUserDto dto)
        {
            if (await _userRepository.IsExistAsync(dto.Email))
            {
                return ServiceResponse.Error($"User with mail: {dto.Email} is already exists");
            }
            var entity = _mapper.Map<UserEntity>(dto);
            entity.Roles = new List<RoleEntity>();

            var defaultRole = await _role.GetByNameAsync("Guest");
            if (defaultRole != null)
            {
                entity.Roles.Add(defaultRole);
            }

            entity.Cart = new CartEntity();
            

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            entity.Password = passwordHash;
            bool res = await _userRepository.CreateAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Something wrong with creating this user");

            }
            return ServiceResponse.Success("Success!", null);

        }
    }
}
