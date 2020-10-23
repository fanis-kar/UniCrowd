using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.API.Data;
using University.API.Services;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "University")]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityController(ApplicationDbContext context)
        {
            _universityRepository = new UniversityRepository(context);
        }

        // GET api/University
        [HttpGet]
        public ActionResult<IEnumerable<Models.University>> GetUniversities()
        {
            return _universityRepository.GetUniversities().ToList();
        }

        // GET api/University/{id}
        [HttpGet("{id}", Name = "GetUniversity")]
        public ActionResult<Models.University> GetUniversity(int id)
        {
            return _universityRepository.GetUniversity(id);
        }

        // GET api/University/{id}
        //[HttpGet("{id}", Name = "GetByUserId")]
        //public ActionResult<Models.University> GetUniversityByUserId(int id)
        //{
        //    return _universityRepository.GetUniversityByUserId(id);
        //}
    }
}
