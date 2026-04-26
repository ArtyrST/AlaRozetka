using AlaBackEnd.BLL.dto;
using AlaBackEnd.BLL.Services.Interfaces;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace AlaBackEnd.BLL.Services.ProductsService
{
    public class ProductCartService : IProductCartInterface
    {
        private readonly ProductCartRepository _cart;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly IMapper _mapper;
        public ProductCartService(ProductCartRepository cart, IHttpContextAccessor httpAccessor, IMapper mapper)
        {
            _cart = cart;
            _httpAccessor = httpAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse> GetUserCartAsync()
        {
            var user = _httpAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (user == null)
            {
                return ServiceResponse.Error("User with this id was not found");
            }

            var entity = await _cart.GetByUserIdAsync(int.Parse(user));
            if (entity == null)
            {
                return ServiceResponse.Error("Cart was not found");
            }

            var dto = _mapper.Map<CartDto>(entity);

            return ServiceResponse.Success("", dto);

        }
    }
}
