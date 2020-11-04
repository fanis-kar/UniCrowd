﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using UniversityWebApplication.ApiCollection;
using UniversityWebApplication.ApiCollection.Interfaces;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.Controllers
{
    public class TaskController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly ITaskApi _taskApi;
        private readonly ISkillApi _skillApi;
        private readonly IStatusApi _statusApi;

        public TaskController(IAuthenticationApi authenticationApi, ITaskApi taskApi, ISkillApi skillApi, IStatusApi statusApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _taskApi = taskApi ?? throw new ArgumentNullException(nameof(taskApi));
            _skillApi = skillApi ?? throw new ArgumentNullException(nameof(skillApi));
            _statusApi = statusApi ?? throw new ArgumentNullException(nameof(statusApi));
        }

        // ~/Task
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var tasks = await _taskApi.GetTasks(HttpContext.Session.GetString("jwtToken"));

            return View(tasks);
        }

        // ~/Task/Details/{id}
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var taskInfo = await _taskApi.GetTask(id, HttpContext.Session.GetString("jwtToken"));

            return View(taskInfo);
        }

        //GET: ~/Task/New
        public async Task<ActionResult> NewAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");

            var statuses = await _statusApi.GetStatuses(HttpContext.Session.GetString("jwtToken"));

            TaskFormViewModel taskForm = new TaskFormViewModel()
            {
                Statuses = statuses
            };

            return View("TaskForm", taskForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveAsync(TaskFormViewModel taskVM)
        {
            if (!ModelState.IsValid)
            {
                var taskForm = new TaskFormViewModel
                {
                    Statuses = await _statusApi.GetStatuses(HttpContext.Session.GetString("jwtToken"))
                };

                return View("TaskForm", taskForm);
            }

            if (taskVM.Id == 0)
            {
                List<TaskSkill> y = new List<TaskSkill>();  

                foreach(var x in taskVM.Skills)
                {
                    y.Add(new TaskSkill { SkillId = x });
                }

                Tasks task = new Tasks
                {
                    Name = taskVM.Name,
                    Description = taskVM.Description,
                    VolunteerNumber = taskVM.VolunteerNumber,
                    ExpectedStartDate = taskVM.ExpectedStartDate,
                    ExpectedEndDate = taskVM.ExpectedEndDate,
                    StatusId = taskVM.StatusId,
                    TasksSkills = y
                };

                TempData["skill"] = string.Join(";", taskVM.Skills.ToString());

                await _taskApi.AddTask(task, HttpContext.Session.GetString("jwtToken"));
            }
            else
            {
                //var taskInDb = await _taskApi.GetTask(task.Id, HttpContext.Session.GetString("jwtToken"));

                // Mapper.Map(customer, customerInDb);

                //taskInDb.Name = task.Name;
                //taskInDb.Description = task.Description;
                //taskInDb.VolunteerNumber = task.VolunteerNumber;
                //taskInDb.Created = task.Created;
                //taskInDb.ExpectedStartDate = task.ExpectedStartDate;
                //taskInDb.StartDate = task.StartDate;
                //taskInDb.StatusId = task.StatusId;
                //taskInDb.TasksSkills = task.TasksSkills;

            }

            return RedirectToAction("Index", "Home");
        }

        //----------------------------------------------------------------------------------------//

        public async Task<bool> IsLoggedInAsync()
        {
            var userId = HttpContext.Session.GetString("userId");
            var jwtToken = HttpContext.Session.GetString("jwtToken");

            if (userId == null || jwtToken == null)
            {
                return false;
            }

            if (await _authenticationApi.ValidateUserAsync(int.Parse(userId), jwtToken) == userId)
                return true;

            return false;
        }
    }
}
