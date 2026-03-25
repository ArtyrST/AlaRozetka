using AlaBackEnd.DAL;
using AlaBackEnd.DAL.Entity.Products;
using AlaBackEnd.Entity.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlaBackEnd.API.Controllers
{
    public class Product
    {
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string CategoryName { get; set; }
    }
    [ApiController]
    [Route("apu/addproduct")]
    public class AddProduct : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public AddProduct (AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("body-json")]
        public async Task<IActionResult> Add([FromBody] Product dbo)
        {
            if (dbo == null)
            {
                return BadRequest("Null is not possible");
            }
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == dbo.CategoryName);
            if (category == null)
            {
                return NotFound($"Category with ID {dbo.CategoryName} not found.");
            }
            var product = new BaseProductEntity
            {
                Name = dbo.Name,
                Price = dbo.Price,
                Country = dbo.Country,
                City = dbo.City,
                CategoryId = category.Id,
                CategoryName = category.Name
            };
            _context.AllProducts.Add(product);
            await _context.SaveChangesAsync();
            return StatusCode(201, product);

        }

    }
}
