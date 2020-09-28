using Authentication.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.API.Services
{
    public interface IUserRepository
    {
        User GetUser(int id);
        User GetUserByUsername(string username);
        void AddUser(User user);
        bool UniqueUsername(string username);
        bool UniqueEmail(string email);
    }
}
