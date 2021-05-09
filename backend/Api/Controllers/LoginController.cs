using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IPZLabsVarCinema
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;

        public LoginController(CinemaDbContext dbContext) => _dbContext = dbContext;

        public record LoginBody(string Email, string Password);
        [HttpPost]
        public IActionResult Login([FromBody] LoginBody body)
        {
            var targetUser = _dbContext.Users.FirstOrDefault(user => user.Email == body.Email);
            if (targetUser is null)
            {
                return NotFound("No user with such email");
            }

            if (!Enumerable.SequenceEqual(targetUser.Password, PasswordEncoder.Encode(body.Password)))
            {
                return BadRequest("Incorrect password");
            }

            return Ok(targetUser);
        }
    }
}
