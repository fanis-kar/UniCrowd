using Authentication.API.Data;
using Authentication.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.API.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context; 
        
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUser(string userEmail)
        {
            var user = _context.Users.Where(u => u.Email == userEmail).FirstOrDefault();
            return user;
        }

        public string AddUser(User user)
        {
            string result = "-1";

            if (user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                result = user.Id.ToString();
            }

            return result;

        }
    }
}
