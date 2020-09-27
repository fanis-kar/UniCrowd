using System;

namespace Middleware
{
    public interface IJwtBuilder
    {
        string GetToken(int userId);
        Guid ValidateToken(string token);
    }
}