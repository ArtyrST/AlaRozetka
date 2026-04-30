using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using AlaBackEnd.BLL.Services.LoginService;
using AlaBackEnd.DAL.Entity.ProductCart;
using AlaBackEnd.DAL.Entity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;




namespace AlaBackEnd.BLL.Services
{
    public class UserService 
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _role;
        private readonly PandingUserPerository _panding;
        private readonly EmailVerifService _emailv;
        private readonly ImageService _image;
        private readonly IHttpContextAccessor _httpAccessor;
        
        public UserService(IHttpContextAccessor httpAccessor, ImageService image, EmailVerifService emailv, IMapper mapper, UserRepository userRepository, RoleRepository role, PandingUserPerository panding)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _role = role;
            _panding = panding;
            _emailv = emailv;
            _image = image;
            _httpAccessor = httpAccessor;
        }
        public async Task<ServiceResponse> RegisterUserAsync(PandingUserDto dto)
        {
            dto.Email = dto.Email.Trim();
            if (await _panding.IsExistAsync(dto.Email))
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
            dto.Email = dto.Email.Trim();
            dto.Code = dto.Code.Trim();
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

            var defaultRole = await _role.GetByNameAsync("Guest");
            if (defaultRole != null)
            {
                entity.Roles.Add(defaultRole);
            }

            bool res = await _userRepository.CreateAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Problem with creating user");
            }
            bool panding_delete = await _panding.DeleteEntityAsync(panding);

            return ServiceResponse.Success("Successfuly verificate account", null);

        } 
        public async Task<ServiceResponse> UpdateUserAsync (UpdateUserDto dto)
        {
            if (dto == null)
            {
                return ServiceResponse.Error("The form is null");
            }
            dto.Id = int.Parse(_httpAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var entity = await _userRepository.GetByIdAsync(dto.Id);

            if (entity == null)
            {
                return ServiceResponse.Error("User was not found");
            }

            _mapper.Map(dto, entity);

            if (dto.Avatar != null)
            {
                var saveImage = await _image.SaveImageAsync(dto.Avatar, "Avatars");

                if (entity.Avatar != null)
                {
                    // видали старий файл з диску
                    _image.DeleteImage(entity.Avatar.Path);
                    // онови існуючий запис замість створення нового
                    entity.Avatar.Path = saveImage;
                    entity.Avatar.IsPreview = true;
                }
                else
                {
                    entity.Avatar = new ImageEntity
                    {
                        Path = saveImage,
                        IsPreview = true,
                        ProductId = null
                    };
                }
            }

            var res = await _userRepository.UpdateAsync(entity);

            if (!res)
            {
                return ServiceResponse.Error("Something wrong");
            }
            return ServiceResponse.Success("Successfuly updated profile",null);


            
        }
    }
}
