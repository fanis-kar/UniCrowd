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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Models.University>> Get()
        {
            return _universityRepository.GetUniversities().ToList();
        }

        // GET api/values
        [HttpGet("{id}", Name = "GetByUserId")]
        public ActionResult<Models.University> GetByUserId(int id)
        {
            return _universityRepository.GetUniversityByUserId(id);
        }
    }
}
