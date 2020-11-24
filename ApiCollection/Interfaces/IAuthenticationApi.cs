using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace ApiCollection.Interfaces
{
    public interface IAuthenticationApi
    {
        Task<string> Login(User user);

        Task<string> VolunteerLogin(User user);

        Task<User> GetUser(int userId, string jwtToken);

        Task<string> ValidateUserAsync(int userId, string jwtToken);
    }
}
