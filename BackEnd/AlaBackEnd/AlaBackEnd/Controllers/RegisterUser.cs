using AlaBackEnd.DAL;
using AlaBackEnd.DAL.Entity.Users;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AlaBackEnd.API.Controllers
{

    public class Register
    {
        
        public required string Mail { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string LastName { get; set; }


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
        public async Task<IActionResult> Register([FromBody] Register? dbo)
        {

            if (dbo == null)
            {
                return BadRequest("");
            }

                var newUser = new UserEntity
                {
                    FirstName = dbo.FirstName!,
                    SecondName = dbo.SecondName,
                    LastName = dbo.LastName!,
                    Email = dbo.Mail!
                };
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Register), newUser);
            

            
            

            
            
            
            

        }
    }
}
