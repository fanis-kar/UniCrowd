using MainAuthentication.Data;
using MainAuthentication.Infrastructure;
using MainAuthentication.Models;
using MainAuthentication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace JWTMicroNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenBuilder _tokenBuilder;

        public AuthenticationController(ApplicationDbContext context, ITokenBuilder tokenBuilder)
        {
            _context = context;
            _tokenBuilder = tokenBuilder;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Account account)
        {
            var dbAccount = await _context.Accounts.SingleOrDefaultAsync(u => u.UserName == account.UserName);

            if (dbAccount == null)
            {
                return NotFound("Account not found.");
            }

            // This is just an example, made for simplicity; do not store plain passwords in the database
            // Always hash and salt your passwords
            var isValid = dbAccount.Password == account.Password;

            if (!isValid)
            {
                return BadRequest("Could not authenticate account.");
            }

            var token = _tokenBuilder.BuildToken(account.UserName);

            return Ok(token);
        }

        [HttpGet("verify")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> VerifyToken()
        {
            var username = User
                .Claims
                .SingleOrDefault();

            if (username == null)
            {
                return Unauthorized();
            }

            var accountExists = await _context.Accounts.AnyAsync(u => u.UserName == username.Value);

            if (!accountExists)
            {
                return Unauthorized();
            }

            return NoContent();
        }
    }
}