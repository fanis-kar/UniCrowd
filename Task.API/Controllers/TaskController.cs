﻿using System;
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

        // GET 
        [HttpGet("University/{id}")]
        public ActionResult<IEnumerable<Tasks>> GetTasksByUniversityId([FromRoute] int id)
        {
            return _taskRepository.GetTasksByUniversityId(id).ToList();
        }

        // GET api/Task/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Tasks> GetTask(int id)
        {
            return _taskRepository.GetTask(id);
        }

        // POST api/Task
        [HttpPost]
        [Authorize(Roles = "University")]
        public ActionResult AddTask([FromBody] Tasks task)
        {
            _taskRepository.AddTask(task);

            return new OkResult();
        }

        [HttpPost]
        [Route("Update")]
        [Authorize(Roles = "University")]
        public IActionResult UpdateTask([FromBody] Tasks task)
        {
            _taskRepository.UpdateTask(task);

            return new OkResult();
        }
    }
}
