using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.API.Models;

namespace University.API.Repositories
{
    public interface IFacultyRepository
    {
        IEnumerable<Faculty> GetFaculties();
        Faculty GetFaculty(int facultyId);
        void AddFaculty(Faculty faculty);
        void UpdateFaculty(Faculty faculty);
        void DeleteFaculty(int facultyId);
    }
}
