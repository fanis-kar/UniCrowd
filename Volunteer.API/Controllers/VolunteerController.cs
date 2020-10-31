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
    [Authorize(Roles = "University")]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerController(ApplicationDbContext context)
        {
            _volunteerRepository = new VolunteerRepository(context);
        }

        // GET api/Volunteer
        [HttpGet]
        public ActionResult<IEnumerable<Model.Volunteer>> GetVolunteers()
        {
            return _volunteerRepository.GetVolunteers().ToList();
        }

        // GET api/Volunteer/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Model.Volunteer> GetVolunteer(int id)
        {
            return _volunteerRepository.GetVolunteer(id);
        }
    }
}
