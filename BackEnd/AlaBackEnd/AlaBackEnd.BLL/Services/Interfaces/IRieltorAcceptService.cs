using AlaBackEnd.BLL.dto.UserDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.Services.Interfaces
{
    public interface IRieltorAcceptService
    {
        public Task<ServiceResponse> GetAllRequests();
        public Task<ServiceResponse> CreateRequest(RieltorRequestsDto dto);
    }
}
