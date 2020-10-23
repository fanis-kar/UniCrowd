﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.ApiCollection.Interfaces
{
    public interface IUniversityApi
    {
        Task<University> GetUniversity(int universityId, string jwtToken);
        Task<University> GetUniversityByUserId(int userId, string jwtToken);
    }
}
