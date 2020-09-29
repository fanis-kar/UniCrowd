using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.API.Data;
using University.API.Services;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityRepository _userRepository;

        public UniversityController(ApplicationDbContext context)
        {
            _userRepository = new UniversityRepository(context);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<University.API.Models.University>> Get()
        {
            return _userRepository.GetUniversities().ToList();
        }
    }
}
