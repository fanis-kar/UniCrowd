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

        // ~/Task/All
        public async Task<IActionResult> AllAsync()
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

            ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");

            var taskInfo = await _taskApi.GetTask(id, HttpContext.Session.GetString("jwtToken"));

            List<Volunteer> volunteers = new List<Volunteer>();

            if (taskInfo.Group != null && taskInfo.Group.VolunteersGroups.Count() > 0)
            {
                foreach (var volunteer in taskInfo.Group.VolunteersGroups)
                {
                    volunteers.Add(await _volunteerApi.GetVolunteer(volunteer.VolunteerId, HttpContext.Session.GetString("jwtToken")));
                }
            }

            TaskDetailsViewModel taskDetailsViewModel = new TaskDetailsViewModel()
            {
                Task = taskInfo,
                Skills = await GetCurrentSkillsAsync(taskInfo.Id),
                Volunteers = volunteers
            };

            return View(taskDetailsViewModel);
        }

        //GET: ~/Task/New
        public async Task<ActionResult> NewAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");

            NewTaskFormViewModel newTaskFormViewModel = new NewTaskFormViewModel();

            return View("New", newTaskFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewAsync(NewTaskFormViewModel taskVM)
        {
            if (!ModelState.IsValid)
            {
                ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");

                TempData["ErrorMessage"] = "Κάτι πήγε στραβά κατά τη δημιουργία του Task.";

                return RedirectToAction("Index", "Home");
            }

            University university = await _universityApi.GetUniversityByUserId(Int32.Parse(HttpContext.Session.GetString("userId")), HttpContext.Session.GetString("jwtToken"));
            List<TaskSkill> skillsRequired = new List<TaskSkill>();

            if (university == null || taskVM.Skills == null)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά κατά τη δημιουργία του Task.";

                return RedirectToAction("Index", "Home");
            }

            foreach (var skillItem in taskVM.Skills)
            {
                skillsRequired.Add(new TaskSkill { SkillId = skillItem });
            }

            Group group = new Group()
            {
                Name = taskVM.GroupName
            };

            Tasks task = new Tasks
            {
                Name = taskVM.Name,
                Description = taskVM.Description,
                VolunteerNumber = taskVM.VolunteerNumber,
                Created = DateTime.Now,
                ExpectedStartDate = taskVM.ExpectedStartDate,
                ExpectedEndDate = taskVM.ExpectedEndDate,
                StatusId = 1,
                UniversityId = university.Id,
                TasksSkills = skillsRequired,
                Group = group
            };
     
            await _taskApi.AddTask(task, HttpContext.Session.GetString("jwtToken"));

            TempData["SuccessMessage"] = "Το Task δημιουργήθηκε με επιτυχία.";

            return RedirectToAction("Index", "Home");
        }

        //GET: ~/Task/Update
        public async Task<ActionResult> UpdateAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");

            Tasks taskInDb = await _taskApi.GetTask(id, HttpContext.Session.GetString("jwtToken"));

            if(taskInDb == null)
            {
                TempData["ErrorMessage"] = "Το Task δε βρέθηκε.";
                return RedirectToAction("Index", "Home");
            }

            var statuses = await _statusApi.GetStatuses(HttpContext.Session.GetString("jwtToken"));
            statuses.RemoveAt(0);

            UpdateTaskFormViewModel updateTaskForm = new UpdateTaskFormViewModel()
            {
                Id = taskInDb.Id,
                Name = taskInDb.Name,
                Description = taskInDb.Description,
                VolunteerNumber = taskInDb.VolunteerNumber,
                ExpectedStartDate = taskInDb.ExpectedStartDate,
                ExpectedEndDate = taskInDb.ExpectedEndDate,
                StatusId = taskInDb.StatusId,
                Statuses = statuses
            };

            return View("Update", updateTaskForm);
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

        public async Task<string> GetCurrentSkillsAsync(int taskId)
        {
            var taskInfo = await _taskApi.GetTask(taskId, HttpContext.Session.GetString("jwtToken"));

            string skills = "[ ";

            if (taskInfo.TasksSkills != null && taskInfo.TasksSkills.Count() > 0)
            {
                foreach (var skill in taskInfo.TasksSkills)
                {
                    skills = skills + "\"" + skill.SkillId.ToString() + "\", ";
                }

                int index = skills.LastIndexOf(',');
                skills = skills.Remove(index, 1);
            }

            skills += "]";

            return skills;
        }
    }
}
