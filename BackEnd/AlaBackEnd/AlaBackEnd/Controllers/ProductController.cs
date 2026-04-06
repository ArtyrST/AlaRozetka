using AlaBackEnd.API.Extensions;
using AlaBackEnd.BLL.dto;
using AlaBackEnd.BLL.Services;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

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
        public async Task<IActionResult> GetAsync()
        {
            var response = await _productService.GetAllAsync();
            return this.GetResult(response);
        }
        [HttpGet("by-id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _productService.GetByIdAsync(id);
            return this.GetResult(response);
        }
        [HttpPost("from-body")]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto dto)
        {
            var response = await _productService.CreateAsync(dto);
            return this.GetResult(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromForm] UpdateProductDto dto)
        {
            var response = await _productService.UpdateAsync(dto);
            return this.GetResult(response);
        }

    }
}
