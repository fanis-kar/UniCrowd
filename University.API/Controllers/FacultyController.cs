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
    [Authorize]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyController(ApplicationDbContext context)
        {
            _facultyRepository = new FacultyRepository(context);
        }

        // GET api/Faculty
        [HttpGet]
        public ActionResult<IEnumerable<Faculty>> GetFaculties()
        {
            return _facultyRepository.GetFaculties().ToList();
        }

        // GET api/Faculty/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Faculty> GetFaculty(int id)
        {
            return _facultyRepository.GetFaculty(id);
        }
    }
}
