using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volunteer.API.Data;
using Volunteer.API.Repositories;
using Volunteer.API.Repositories.Interfaces;

namespace Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerController(ApplicationDbContext context)
        {
            _volunteerRepository = new VolunteerRepository(context);
        }

        // GET ~/api/Volunteer
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Model.Volunteer>> GetVolunteers()
        {
            return _volunteerRepository.GetVolunteers().ToList();
        }

        // GET ~/api/Volunteer/{id}
        [HttpGet("{id:int}")]
        [Authorize]
        public ActionResult<Model.Volunteer> GetVolunteer(int id)
        {
            return _volunteerRepository.GetVolunteer(id);
        }

        // GET ~/api/Volunteer/User/{id}
        [HttpGet("User/{id}")]
        [Authorize]
        public ActionResult<Model.Volunteer> GetVolunteerByUserId([FromRoute] int id)
        {
            return _volunteerRepository.GetVolunteerByUserId(id);
        }

        // POST ~/api/Volunteer
        [HttpPost]
        [Authorize(Roles = "Volunteer")]
        public ActionResult AddVolunteer([FromBody] Model.Volunteer volunteer)
        {
            _volunteerRepository.AddVolunteer(volunteer);

            return new OkResult();
        }

        // POST ~/api/Volunteer/Update
        [HttpPost]
        [Route("Update")]
        [Authorize(Roles = "Volunteer")]
        public IActionResult UpdateVolunteer([FromBody] Model.Volunteer volunteer)
        {
            _volunteerRepository.UpdateVolunteer(volunteer);

            return new OkResult();
        }
    }
}
