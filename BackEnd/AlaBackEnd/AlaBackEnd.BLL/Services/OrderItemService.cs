using AlaBackEnd.BLL.dto;

using AlaBackEnd.DAL.Entity.ProductCart;
using AlaBackEnd.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AlaBackEnd.BLL.Services
{
    public class OrderItemService
    {
        private readonly OrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ProductRepository _product;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly UserRepository _user;
        public OrderItemService(OrderRepository orderRepository, IMapper mapper, ProductRepository product, IHttpContextAccessor httpAccessor, UserRepository user)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _product = product;
            _httpAccessor = httpAccessor;
            _user = user;
        }
        public async Task<ServiceResponse> CreateOrderAsync(CreateOrderDto dto)
        {
            if (dto == null)
            {
                return ServiceResponse.Error("The form is null");
            }
            
            var entity = _mapper.Map<OrderItemEntity>(dto);
            entity.ProductId = dto.ProductId;
            var rieltor = await _product.GetByIdAsync(dto.ProductId);
            if (rieltor == null)
            {
                return ServiceResponse.Error("Rieltor was not found");
            }
            entity.RieltorId = rieltor.Id;
            entity.VisitorsCount = dto.VisitorsCount;

            
            
                        if (!await _orderRepository.IsDateOverlap(dto.ProductId, DateTime.Parse(dto.From), DateTime.Parse(dto.To)))
                        {
                            return ServiceResponse.Error(@"Ця дата вже заброньована");
                        }
            
            
            entity.TimeFrom = DateTime.Parse(dto.From).ToUniversalTime();
            entity.TimeTo = DateTime.Parse(dto.To).ToUniversalTime();

            TimeSpan duration = entity.TimeTo - entity.TimeFrom;

            double period = duration.TotalDays;
            var userId = _httpAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            entity.UserId = int.Parse(userId);

            entity.TotalPrice = await _orderRepository.PriceCounterAsync(period, entity.ProductId);



            var user = await _user.GetByIdAsync(entity.UserId);
            if (user == null)
            {
                return ServiceResponse.Error("User was not found");
            }
            entity.CartId = user.Cart.Id;


            bool res = await _orderRepository.CreateAsync(entity);
            if (!res)
            {
                return ServiceResponse.Error("Problem with making order!");
            }

            return ServiceResponse.Success("Successfull!", null);


        }
    }
}
