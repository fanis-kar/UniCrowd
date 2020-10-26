using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.API.Data;
using Model;

namespace University.API.Services
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly ApplicationDbContext _context;

        public UniversityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Model.University> GetUniversities()
        {
            return _context
                .Universities
                .Include(u => u.Faculties)
                .ToList();
        }

        public Model.University GetUniversity(int universityId)
        {
            return _context.Universities
                .Include(u => u.Faculties)
                .Where(u => u.Id == universityId)
                .FirstOrDefault();
        }

        public Model.University GetUniversityByUserId(int userId)
        {
            return _context.Universities
                .Include(u => u.Faculties)
                .Where(u => u.AccountId == userId)
                .FirstOrDefault();
        }

        public void AddUniversity(Model.University university)
        {
            throw new NotImplementedException();
        }

        public void UpdateUniversity(Model.University university)
        {
            throw new NotImplementedException();
        }

        public void DeleteUniversity(int universityId)
        {
            throw new NotImplementedException();
        }
    }
}
