using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.API.Data;
using Model;
using University.API.Repositories;
using University.API.Services;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "University")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(ApplicationDbContext context)
        {
            _departmentRepository = new DepartmentRepository(context);
        }

        // GET api/Department
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            return _departmentRepository.GetDepartments().ToList();
        }

        // GET api/Department/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            return _departmentRepository.GetDepartment(id);
        }
    }
}
