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
        [FromQuery(Name = "d")] string destination = "frontend")
        {
            var u = _userRepository.GetUserByUsername(user.Username); 
            
            if (u == null)
            {
                return NotFound("Ο χρήστης δε βρέθηκε.");
            }

            //if (destination == "backend" && u.RoleId != 1)
            //{
            //    return BadRequest("Δεν ήταν δυνατή η ταυτοποίηση του χρήστη.");
            //}

            var isValid = u.ValidatePassword(user.Password, _encryptor); 
            
            if (!isValid)
            {
                return BadRequest("Δεν ήταν δυνατή η ταυτοποίηση του χρήστη.");
            }

            string token = _jwtBuilder.GetToken(u.Id, u.RoleId);
            
            return new OkObjectResult(token);
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
        public IActionResult Validate([FromQuery(Name = "email")] int id,
        [FromQuery(Name = "token")] string token)
        {
            var u = _userRepository.GetUser(id); 
            
            if (u == null)
            {
                return NotFound("User not found.");
            }

            var userId = _jwtBuilder.ValidateToken(token); 
            
            if (!userId.Equals(u.Id))
            {
                return BadRequest("Invalid token.");
            }
            return new OkObjectResult(userId);
        }
    }
}
