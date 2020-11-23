using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace University.API.Services
{
    public interface IUniversityRepository
    {
        IEnumerable<Model.University> GetUniversities();

        Model.University GetUniversity(int universityId);

        Model.University GetUniversityByUserId(int userId);

        void AddUniversity(Model.University university);

        void UpdateUniversity(Model.University university);

        void DeleteUniversity(int universityId);
    }
}
