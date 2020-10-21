using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.API.Data;
using University.API.Models;

namespace University.API.Services
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly ApplicationDbContext _context;

        public UniversityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUniversity(Models.University university)
        {
            throw new NotImplementedException();
        }

        public void DeleteUniversity(int universityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.University> GetUniversities()
        {
            return _context
                .Universities
                .Include(u => u.Faculties)
                .ToList();
        }

        public Models.University GetUniversity(int universityId)
        {
            return _context.Universities.Where(u => u.Id == universityId).FirstOrDefault();
        }

        public Models.University GetUniversityByUserId(int userId)
        {
            return _context.Universities
                .Include(u => u.Faculties)
                .Where(u => u.AccountId == userId)
                .FirstOrDefault();
        }

        public void UpdateUniversity(Models.University university)
        {
            throw new NotImplementedException();
        }
    }
}
