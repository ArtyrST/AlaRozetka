using AlaBackEnd.BLL.dto;
using AlaBackEnd.DAL.Entity;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace AlaBackEnd.BLL.Services
{
    public class FeedBackService
    {
        private readonly FeedBackRepository _feedbacks;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public FeedBackService(FeedBackRepository service, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _feedbacks = service;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        public async Task<ServiceResponse> CreateAsync(CreateFeedBackDto dto)
        {
            if (dto == null)
            {
                return ServiceResponse.Error("The form is null");
            }
            if (dto.StarCount > 5)
            {
                return ServiceResponse.Error("Stars count can't by >= 5");
            }
            var entity = _mapper.Map<FeedBackEntity>(dto);

            

            entity.UserId = int.Parse(_contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));

            bool res = await _feedbacks.CreateAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Something wrong!");
            }
            return ServiceResponse.Success("Feedback was added", null);
        }
    }
}
