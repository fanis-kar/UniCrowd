using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.ApiCollection.Interfaces
{
    public interface IFacultyApi
    {
        Task<Faculty> GetFaculty(int facultyId, string jwtToken);
    }
}
