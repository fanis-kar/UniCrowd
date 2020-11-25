using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Task.API.Data;
using Task.API.Repositories;
using Task.API.Repositories.Interfaces;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;

        public SkillController(ApplicationDbContext context)
        {
            _skillRepository = new SkillRepository(context);
        }

        // GET ~/api/Skill
        [HttpGet]
        public ActionResult<IEnumerable<Skill>> GetSkills()
        {
            return _skillRepository.GetSkills().ToList();
        }

        // GET ~/api/Skill/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Skill> GetSkill(int id)
        {
            return _skillRepository.GetSkill(id);
        }

        // GET ~/api/Volunteer/{id} 
        [HttpGet("Volunteer/{id}")]
        public ActionResult<IEnumerable<Skill>> GetVolunteerSkills([FromRoute] int id)
        {
            return _skillRepository.GetVolunteerSkills(id).ToList();
        }

        [HttpPost]
        [Route("Volunteer/Update/{id}")]
        [Authorize(Roles = "Volunteer")]
        public IActionResult UpdateVolunteerSkills([FromRoute] int id, [FromBody] List<int> skills)
        {
            _skillRepository.UpdateVolunteerSkills(id, skills);

            return new OkResult();
        }
    }
}
