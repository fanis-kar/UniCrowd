using Authentication.API.Data;
using Model;
using System.Linq;

namespace Authentication.API.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context; 
        
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool UniqueUsername(string username)
        {
            if (_context.Users.Where(u => u.Username == username).Count() > 0)
            {
                return false;
            }

            return true;
        }

        public bool UniqueEmail(string email)
        {
            if (_context.Users.Where(u => u.Email == email).Count() > 0)
            {
                return false;
            }

            return true;
        }
    }
}
