using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
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
    [Authorize(Roles = "University")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(ApplicationDbContext context, IBus bus)
        {
            _groupRepository = new GroupRepository(context, bus);
        }

        // GET api/Group
        [HttpGet]
        public ActionResult<IEnumerable<Group>> GetGroups()
        {
            return _groupRepository.GetGroups().ToList();
        }

        // GET  api/Group/Volunteer/{id}
        [HttpGet("Volunteer/{id}")]
        public ActionResult<IEnumerable<Group>> GetVolunteerGroups([FromRoute] int id)
        {
            return _groupRepository.GetVolunteerGroups(id).ToList();
        }

        // GET api/Group/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Group> GetGroup(int id)
        {
            return _groupRepository.GetGroup(id);
        }

        // POST api/Group
        [HttpPost]
        public ActionResult AddGroup([FromBody] Group group)
        {
            _groupRepository.AddGroup(group);

            return new OkResult();
        }

        // POST ~/api/Group/Update
        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateGroup([FromBody] Group group)
        {
            _groupRepository.UpdateGroupAsync(group);

            return new OkResult();
        }
    }
}
