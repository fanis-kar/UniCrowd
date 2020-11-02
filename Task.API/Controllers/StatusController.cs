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
        private readonly ITaskRepository _taskRepository;

        public StatusController(ApplicationDbContext context)
        {
            _taskRepository = new TaskRepository(context);
        }

        // GET ~/api/Status
        [HttpGet]
        public ActionResult<IEnumerable<Status>> GetStatuses()
        {
            return _taskRepository.GetStatuses().ToList();
        }

        // GET ~/api/Status/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Status> GetStatus(int id)
        {
            return _taskRepository.GetStatus(id);
        }
    }
}
