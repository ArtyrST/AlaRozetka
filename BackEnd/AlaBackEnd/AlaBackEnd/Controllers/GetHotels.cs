using AlaBackEnd.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlaBackEnd.API.Controllers
{
    [ApiController]
    [Route("api/hotels")]
    public class GetHotelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GetHotelsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetHotels()
        {
            var hotels = await _context.AllProducts
                .AsNoTracking()
                .ToListAsync(); 
            return Ok(hotels);
        }

    }

}
