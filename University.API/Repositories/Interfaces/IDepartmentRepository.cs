using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace University.API.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int departmentId);
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int departmentId);
    }
}
