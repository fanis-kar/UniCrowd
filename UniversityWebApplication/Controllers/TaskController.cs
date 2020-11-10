using System;
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
        private readonly IUniversityApi _universityApi;
        private readonly IVolunteerApi _volunteerApi;
        private readonly ITaskApi _taskApi;
        private readonly IGroupApi _groupApi;
        private readonly ISkillApi _skillApi;
        private readonly IStatusApi _statusApi;

        public TaskController(IAuthenticationApi authenticationApi, IUniversityApi universityApi, IVolunteerApi volunteerApi, ITaskApi taskApi, IGroupApi groupApi, ISkillApi skillApi, IStatusApi statusApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _universityApi = universityApi ?? throw new ArgumentNullException(nameof(universityApi));
            _volunteerApi = volunteerApi ?? throw new ArgumentNullException(nameof(volunteerApi));
            _taskApi = taskApi ?? throw new ArgumentNullException(nameof(taskApi));
            _groupApi = groupApi ?? throw new ArgumentNullException(nameof(groupApi));
            _skillApi = skillApi ?? throw new ArgumentNullException(nameof(skillApi));
            _statusApi = statusApi ?? throw new ArgumentNullException(nameof(statusApi));
        }

        // ~/Task
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            University university = await _universityApi.GetUniversityByUserId(Int32.Parse(HttpContext.Session.GetString("userId")), HttpContext.Session.GetString("jwtToken"));
            var myTasks = await _taskApi.GetTasksByUniversityId(university.Id, HttpContext.Session.GetString("jwtToken"));

            return View(myTasks);
        }

        // ~/Task/Details/{id}
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");

            var taskInfo = await _taskApi.GetTask(id, HttpContext.Session.GetString("jwtToken"));

            List<Volunteer> volunteers = new List<Volunteer>();

            string skillsRequired = "[ ";

            if (taskInfo.TasksSkills != null && taskInfo.TasksSkills.Count() > 0)
            {
                foreach (var skill in taskInfo.TasksSkills)
                {
                    skillsRequired = skillsRequired + "\"" + skill.SkillId.ToString() + "\", ";
                }

                int index = skillsRequired.LastIndexOf(',');
                skillsRequired = skillsRequired.Remove(index, 1);
            }

            skillsRequired += "]";

            if (taskInfo.Group != null && taskInfo.Group.VolunteersGroups.Count() > 0)
            {
                foreach (var volunteer in taskInfo.Group.VolunteersGroups)
                {
                    volunteers.Add(await _volunteerApi.GetVolunteer(volunteer.VolunteerId, HttpContext.Session.GetString("jwtToken")));
                }
            }

            TaskViewModel taskViewModel = new TaskViewModel()
            {
                Task = taskInfo,
                Skills = skillsRequired,
                Volunteers = volunteers
            };

            return View(taskViewModel);
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
                University university = await _universityApi.GetUniversityByUserId(Int32.Parse(HttpContext.Session.GetString("userId")), HttpContext.Session.GetString("jwtToken"));
                List<TaskSkill> skillsRequired = new List<TaskSkill>();

                if (university == null || taskVM.Skills == null || taskVM.StatusId != 1)
                {
                    TempData["ErrorMessage"] = "Κάτι πήγε στραβά κατά τη δημιουργία του Task.";

                    return RedirectToAction("Index", "Home");
                }

                foreach (var skillItem in taskVM.Skills)
                {
                    skillsRequired.Add(new TaskSkill { SkillId = skillItem });
                }

                Tasks task = new Tasks
                {
                    Name = taskVM.Name,
                    Description = taskVM.Description,
                    VolunteerNumber = taskVM.VolunteerNumber,
                    Created = DateTime.Now,
                    ExpectedStartDate = taskVM.ExpectedStartDate,
                    ExpectedEndDate = taskVM.ExpectedEndDate,
                    StatusId = taskVM.StatusId,
                    UniversityId = university.Id,
                    TasksSkills = skillsRequired
                };
                
                await _taskApi.AddTask(task, HttpContext.Session.GetString("jwtToken"));

                //---------------//


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
