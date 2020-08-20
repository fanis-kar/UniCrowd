using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainAuthentication.Infrastructure
{
    public interface ITokenBuilder
    {
        string BuildToken(string username);
    }
}
