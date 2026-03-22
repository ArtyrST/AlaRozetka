using AlaBackEnd.DAL;
using AlaBackEnd.DAL.Entity.Users;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Mvc;

namespace AlaBackEnd.API.Controllers
{

    public class Register
    {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }



    }
    [ApiController]
    [Route("api/register")]
    public class RegisterUser : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegisterUser(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("body-json")]
        public async Task<IActionResult> Register([FromBody] Register dbo)
        {
            var newUser = new UserEntity
            {
                FirstName = dbo.Name,
                LastName = dbo.LastName,
                Email = dbo.Mail
            };
            _context.Users.Add(newUser);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Register), newUser);

        }
    }
}
