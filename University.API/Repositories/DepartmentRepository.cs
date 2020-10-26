using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.API.Data;
using Model;

namespace University.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context
                .Departments
                .Include(d => d.Faculty)
                .ToList();
        }

        public Department GetDepartment(int departmentId)
        {
            return _context.Departments
                .Include(d => d.Faculty)
                .Where(d => d.Id == departmentId)
                .FirstOrDefault();
        }

        public void AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
