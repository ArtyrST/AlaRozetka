using AlaBackEnd.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlaBackEnd.API.Controllers
{
    [ApiController]
    [Route("api/username")]
    public class GetUserName : ControllerBase
    {
        private readonly AppDbContext _context;

        public GetUserName(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetNames()
        {
            var users = await _context.Users
                .Where(i => i.Id <= 10)
                .Select(i => i)
                .AsNoTracking()
                .ToListAsync();
            return Ok(users);
        }
    }
}
