using AlaBackEnd.API.Extensions;
using AlaBackEnd.BLL.dto;
using AlaBackEnd.BLL.Services;
using AlaBackEnd.BLL.Services.ProductsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;

namespace AlaBackEnd.API.Controllers
{
    
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly OrderItemService _orderItemService;
        private readonly FeedBackService _feedbackService;
        private readonly AdditionalServicesService _addService;
        

        public ProductController(AdditionalServicesService addService, ProductService productService, OrderItemService orderItemService, FeedBackService feedBackService)
        {
            _productService = productService;
            _orderItemService = orderItemService;
            _feedbackService = feedBackService;
            _addService = addService;
        }
        //[Authorize]
        [HttpGet] 
        public async Task<IActionResult> GetAsync([FromQuery] int PageNumber)
        {
            var response = await _productService.GetAllAsync(PageNumber, 20);
            
            return this.GetResult(response);
        }
        [Authorize(Roles = "Admin")]
        
        [HttpGet("by-id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _productService.GetByIdAsync(id);
            return this.GetResult(response);
        }
        [HttpGet("by-tag")]

        public async Task<IActionResult> GetByTagAsync([FromQuery]List<int> tagIds)
        {
            var response = await _productService.GetByTagAsync(tagIds);
            return this.GetResult(response);
        }
        //[Authorize(Roles = "Rieltor")]
        [HttpPost("from-form")]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductDto dto)
        {
            var response = await _productService.CreateAsync(dto);
            return this.GetResult(response);
        }
        [Authorize(Roles = "Rieltor")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProductAsync([FromForm] UpdateProductDto dto)
        {
            var response = await _productService.UpdateAsync(dto);
            return this.GetResult(response);
        }
        [Authorize(Roles = "Rieltor")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var response = await _productService.DeleteAsync(id);
            return this.GetResult(response);
        }
        [Authorize(Roles = "Rieltor")]
        [HttpDelete("delete-range")]
        public async Task<IActionResult> DeleteRangeProductsAsync([FromQuery] List<int> ids)
        {
            var response = await _productService.DeleteRangeAsync(ids);
            return this.GetResult(response);
        }
        [Authorize(Roles = "Guest")]
        [HttpPost("make-order")]
        public async Task<IActionResult> MakeOrderAsync([FromForm] CreateOrderDto dto)
        {
            var response = await _orderItemService.CreateOrderAsync(dto);
            return this.GetResult(response);
        }
        [Authorize(Roles = "Guest")]
        [HttpPost("create-feedback")]
        public async Task<IActionResult> CreateFeedBackAsync([FromForm] CreateFeedBackDto dto)
        {
            var response = await _feedbackService.CreateAsync(dto);
            return this.GetResult(response);
        }
        //[Authorize(Roles = "Guest")]
        [HttpGet("get-additional-services")]
        public async Task<IActionResult> GetAdditionalServices()
        {
            var response = await _addService.GetAllServices();
            return this.GetResult(response);
        }


    }
}
