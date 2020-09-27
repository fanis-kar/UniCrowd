using Authentication.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.API.Services
{
    public interface IUserRepository
    {
        User GetUser(string email);
        string AddUser(User user);
    }
}
