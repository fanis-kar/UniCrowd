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
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ApplicationDbContext context)
        {
            _taskRepository = new TaskRepository(context);
        }

        // GET api/Task
        [HttpGet]
        public ActionResult<IEnumerable<Tasks>> GetTasks()
        {
            return _taskRepository.GetTasks().ToList();
        }

        // GET api/Task/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Tasks> GetTask(int id)
        {
            return _taskRepository.GetTask(id);
        }

        // POST api/Task
        [HttpPost]
        public ActionResult Post([FromBody] Tasks task)
        {
            _taskRepository.AddTask(task);

            return new OkResult();
        }

        // GET api/Skill
        [HttpGet]
        public ActionResult<IEnumerable<Skill>> GetSkills()
        {
            return _taskRepository.GetSkills().ToList();
        }

        // GET api/Skill/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Skill> GetSkill(int id)
        {
            return _taskRepository.GetSkill(id);
        }
    }
}
