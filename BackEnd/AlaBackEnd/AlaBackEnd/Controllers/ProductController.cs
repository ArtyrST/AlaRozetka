using AlaBackEnd.API.Extensions;
using AlaBackEnd.BLL.dto;
using AlaBackEnd.BLL.Services;

using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;

namespace AlaBackEnd.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAsync([FromQuery] int PageNumber)
        {
            var response = await _productService.GetAllAsync(PageNumber, 20);
            return this.GetResult(response);
        }
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
        [HttpPost("from-form")]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductDto dto)
        {
            var response = await _productService.CreateAsync(dto);
            return this.GetResult(response);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProductAsync([FromForm] UpdateProductDto dto)
        {
            var response = await _productService.UpdateAsync(dto);
            return this.GetResult(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var response = await _productService.DeleteAsync(id);
            return this.GetResult(response);
        }


    }
}
