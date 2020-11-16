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
    [Authorize(Roles = "University")]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationRepository _invitationRepository;

        public InvitationController(ApplicationDbContext context)
        {
            _invitationRepository = new InvitationRepository(context);
        }

        // GET ~/api/Invitation
        [HttpGet]
        public ActionResult<IEnumerable<Invitation>> GetInvitations()
        {
            return _invitationRepository.GetInvitations().ToList();
        }

        // GET ~/api/Invitation/Task/{id}
        [HttpGet("Task/{id}")]
        public ActionResult<IEnumerable<Invitation>> GetInvitationsByTaskId([FromRoute] int id)
        {
            return _invitationRepository.GetInvitationsByTaskId(id).ToList();
        }

        // GET ~/api/Invitation/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Invitation> GetInvitation(int id)
        {
            return _invitationRepository.GetInvitation(id);
        }

        // POST ~/api/Invitation
        [HttpPost]
        public ActionResult AddInvitation(Invitation invitation)
        {
            _invitationRepository.AddInvitation(invitation);

            return new OkResult();
        }

        // POST ~/api/Invitation/Update
        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateInvitation([FromBody] Invitation invitation)
        {
            _invitationRepository.UpdateInvitation(invitation);

            return new OkResult();
        }
    }
}
