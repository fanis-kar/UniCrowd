﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class LoginForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? RememberMe { get; set; }
    }
}
