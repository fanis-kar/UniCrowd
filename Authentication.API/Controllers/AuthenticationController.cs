using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.API.Data;
using Authentication.API.Models;
using Authentication.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Middleware;
using Newtonsoft.Json;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtBuilder _jwtBuilder;
        private readonly IEncryptor _encryptor; 
        
        public AuthenticationController(ApplicationDbContext context, IJwtBuilder jwtBuilder, IEncryptor encryptor)
        {
            _userRepository = new UserRepository(context);
            _jwtBuilder = jwtBuilder;
            _encryptor = encryptor;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user,
        [FromQuery(Name = "destination")] string destination = "volunteer-area")
        {
            var u = _userRepository.GetUserByUsername(user.Username); 
            
            if (u == null)
            {
                return NotFound("Ο χρήστης δε βρέθηκε.");
            }

            if ((destination == "university-area" && u.RoleId != 1) || (destination == "volunteer-area" && u.RoleId != 2))
            {
                return BadRequest("Δεν επιτρέπεται η πρόσβαση.");
            }

            var isValid = u.ValidatePassword(user.Password, _encryptor); 
            
            if (!isValid)
            {
                return BadRequest("Λάθος στοιχεία.");
            }

            string token = _jwtBuilder.GetToken(u.Id, u.RoleId);

            var result = new { userId = u.Id, jwtToken = token };
            var resultObject = JsonConvert.SerializeObject(result);

            return new OkObjectResult(resultObject);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var u = _userRepository.GetUser(user.Id); 
            
            if (u != null)
            {
                return BadRequest("Ο χρήστης υπάρχει ήδη.");
            }

            if (!_userRepository.UniqueUsername(user.Username))
            {
                return BadRequest("Το username υπάρχει ήδη.");
            }

            if (!_userRepository.UniqueEmail(user.Email))
            {
                return BadRequest("Το email υπάρχει ήδη.");
            }

            user.SetPassword(user.Password, _encryptor);
            _userRepository.AddUser(user); 
            
            return Ok();
        }

        [HttpGet("validate")]
        public IActionResult Validate([FromQuery(Name = "userId")] int id,
        [FromQuery(Name = "jwtToken")] string token)
        {
            var u = _userRepository.GetUser(id); 
            
            if (u == null)
            {
                return NotFound("Ο χρήστης δε βρέθηκε.");
            }

            var userId = _jwtBuilder.ValidateToken(token); 
            
            if (!userId.Equals(u.Id))
            {
                return BadRequest("Δεν επιτρέπεται η πρόσβαση. Μη έγκυρο token.");
            }
            return new OkObjectResult(userId);
        }
    }
}
