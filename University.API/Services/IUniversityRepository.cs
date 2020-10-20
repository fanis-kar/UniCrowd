using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.API.Services
{
    public interface IUniversityRepository
    {
        IEnumerable<University.API.Models.University> GetUniversities();
        University.API.Models.University GetUniversity(int universityId);
        University.API.Models.University GetUniversityByUserId(int userId);
        void AddUniversity(University.API.Models.University university);
        void UpdateUniversity(University.API.Models.University university);
        void DeleteUniversity(int universityId);
    }
}
