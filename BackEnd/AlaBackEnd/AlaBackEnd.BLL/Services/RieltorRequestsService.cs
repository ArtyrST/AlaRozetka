using AlaBackEnd.BLL.dto.UserDto;
using AlaBackEnd.BLL.Services.Interfaces;
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
        
        public RieltorRequestsService(RieltorRequestsRepository requests, IMapper mapper, IHttpContextAccessor httpAccess)
        {
            _requests = requests;
            _mapper = mapper;
            _httpAccess = httpAccess;
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
    }
}
