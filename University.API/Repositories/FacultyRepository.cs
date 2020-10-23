using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.API.Data;
using University.API.Models;

namespace University.API.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly ApplicationDbContext _context;

        public FacultyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            return _context
                .Faculties
                .Include(f => f.Departments)
                .ToList();
        }

        public Faculty GetFaculty(int facultyId)
        {
            return _context.Faculties
                .Include(f => f.Departments)
                .Where(f => f.Id == facultyId)
                .FirstOrDefault();
        }

        public void AddFaculty(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        public void UpdateFaculty(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        public void DeleteFaculty(int facultyId)
        {
            throw new NotImplementedException();
        }
    }
}
