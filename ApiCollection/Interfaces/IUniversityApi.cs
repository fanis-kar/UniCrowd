using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace ApiCollection.Interfaces
{
    public interface IUniversityApi
    {
        //-----------------------------------------//

        Task<List<University>> GetUniversities(string jwtToken);

        Task<University> GetUniversity(int universityId, string jwtToken);

        Task<University> GetUniversityByUserId(int userId, string jwtToken);

        //-----------------------------------------//

        Task<Faculty> GetFaculty(int facultyId, string jwtToken);

        //-----------------------------------------//

        Task<Department> GetDepartment(int departmentId, string jwtToken);

        //-----------------------------------------//
    }
}
