using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class AuthenticationResponse
    {
        public int userId { get; set; }
        public string jwtToken { get; set; }
        public string Username { get; internal set; }
        public string Password { get; internal set; }
    }
}
