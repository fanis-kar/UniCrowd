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
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(ApplicationDbContext context)
        {
            _statusRepository = new StatusRepository(context);
        }

        // GET ~/api/Status
        [HttpGet]
        public ActionResult<IEnumerable<Status>> GetStatuses()
        {
            return _statusRepository.GetStatuses().ToList();
        }

        // GET ~/api/Status/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Status> GetStatus(int id)
        {
            return _statusRepository.GetStatus(id);
        }
    }
}
