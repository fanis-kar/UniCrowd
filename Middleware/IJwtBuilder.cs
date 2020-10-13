﻿using System;

namespace Middleware
{
    public interface IJwtBuilder
    {
        string GetToken(int userId, int userRole);
        Guid ValidateToken(string token);
    }
}