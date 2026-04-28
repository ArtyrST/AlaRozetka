using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.BLL.Services.Interfaces;
using AlaBackEnd.BLL.Services.LoginService;
using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace AlaBackEnd.BLL.Services
{
    public class RieltorRequestsService : IRieltorAcceptService
    {
        private readonly RieltorRequestsRepository _requests;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpAccess;
        private readonly UserRepository _user;
        private readonly RoleRepository _role;
        private readonly EmailVerifService _emailVerif;
        
        public RieltorRequestsService(EmailVerifService emailVerif, RoleRepository role, UserRepository user, RieltorRequestsRepository requests, IMapper mapper, IHttpContextAccessor httpAccess)
        {
            _requests = requests;
            _mapper = mapper;
            _httpAccess = httpAccess;
            _user = user;
            _role = role;
            _emailVerif = emailVerif;
        }

        public async Task<ServiceResponse> GetAllRequests()
        {
            var entity = _requests.GetAll();
            if (entity == null)
            {
                return ServiceResponse.Error("The list of requests is null");
            }

            

            return ServiceResponse.Success("Success", entity);
        }
        public async Task<ServiceResponse> CreateRequest(RieltorRequestsDto dto)
        {
            if (dto == null)
            {
                return ServiceResponse.Error("The form is null");
            }
            

            var entity = _mapper.Map<RieltorAcceptEntity>(dto);
            entity.UserId = int.Parse(_httpAccess.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            entity.Email = _httpAccess.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
            bool res = await _requests.CreateAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Something wrong");
            }
            return ServiceResponse.Success("Success", null);

            
        }
        public async Task<ServiceResponse> CreateChoiseAsync(AcceptRieltorRoleDto dto)
        {
            if (dto == null)
            {
                return ServiceResponse.Error("The form is empty");
            }
                int requestId = dto.RequestId;
                var requestEntity = await _requests.GetByIdAsync(requestId);
                if (requestEntity == null)
                {
                    return ServiceResponse.Error("No request with this id");
                }
                int userId = requestEntity.UserId;
                var userEntity = await _user.GetByIdAsync(userId);
                if (userEntity == null)
                {
                    return ServiceResponse.Error("No user with this id");
                }
            if (dto.Status == RequestStatus.Accept)
            {
                var role = await _role.GetByNameAsync("Rieltor");
                
                userEntity.Roles.Add(role);

                await _emailVerif.SendAsync(userEntity.Email, "Your request is: ", "Accept");

                await _requests.DeleteEntityAsync(requestEntity);

                return ServiceResponse.Success("This user is now accept for Rieltor role", null);
            }
            else if (dto.Status == RequestStatus.Rejected)
            {
                await _requests.DeleteEntityAsync(requestEntity);
                await _emailVerif.SendAsync(userEntity.Email, "Your request is: ", "Reject");
                return ServiceResponse.Success("This user is now denyed for Rieltor role", null);
            }
            return ServiceResponse.Error("Something wrong with request");
        }
    }
}
