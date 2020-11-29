using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ApiCollection.Interfaces;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.Controllers
{
    public class TaskController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IVolunteerApi _volunteerApi;
        private readonly ITaskApi _taskApi;
        private readonly IStatusApi _statusApi;

        public TaskController(IAuthenticationApi authenticationApi, IVolunteerApi volunteerApi, ITaskApi taskApi, IStatusApi statusApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _volunteerApi = volunteerApi ?? throw new ArgumentNullException(nameof(volunteerApi));
            _taskApi = taskApi ?? throw new ArgumentNullException(nameof(taskApi));
            _statusApi = statusApi ?? throw new ArgumentNullException(nameof(statusApi));
        }

        // GET ~/Task
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var myTasks = await _taskApi.GetTasksByUniversityId(int.Parse(HttpContext.Session.GetString("universityId")), HttpContext.Session.GetString("jwtToken"));
            return View(myTasks);
        }

        // GET ~/Task/All
        public async Task<IActionResult> AllAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var tasks = await _taskApi.GetTasks(HttpContext.Session.GetString("jwtToken"));
            return View(tasks);
        }

        // GET ~/Task/University/{id}
        public async Task<IActionResult> University(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var tasks = await _taskApi.GetTasksByUniversityId(id, HttpContext.Session.GetString("jwtToken"));
            return View(tasks);
        }

        // GET ~/Task/Details/{id}
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");

            var taskInfo = await _taskApi.GetTask(id, HttpContext.Session.GetString("jwtToken"));

            if (taskInfo == null)
            {
                TempData["ErrorMessage"] = "Το Task δε βρέθηκε.";
                return RedirectToAction("Index", "Home");
            }

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

        // GET ~/Task/New
        public async Task<ActionResult> NewAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");

            NewTaskFormViewModel newTaskFormViewModel = new NewTaskFormViewModel();
            return View("New", newTaskFormViewModel);
        }

        // POST ~/Task/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewAsync(NewTaskFormViewModel taskVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά κατά τη δημιουργία του Task.";
                return RedirectToAction("Index", "Home");
            }

            List<TaskSkill> skillsRequired = new List<TaskSkill>();

            if (taskVM.Skills == null)
            {
                TempData["ErrorMessage"] = "Πρέπει να επιλέξετε τουλάχιστον μία ικανότητα.";
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
                UniversityId = int.Parse(HttpContext.Session.GetString("universityId")),
                TasksSkills = skillsRequired,
                Group = group
            };
     
            await _taskApi.AddTask(task, HttpContext.Session.GetString("jwtToken"));

            TempData["SuccessMessage"] = "Το Task δημιουργήθηκε με επιτυχία.";
            return RedirectToAction("Index", "Home");
        }

        //GET ~/Task/Update
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

            if ( taskInDb.UniversityId != int.Parse(HttpContext.Session.GetString("universityId")))
            {
                TempData["ErrorMessage"] = "Δεν μπορείς να ενημερώσεις αυτό το Task.";
                return RedirectToAction("Index", "Home");
            }

            if (taskInDb.StatusId == 3 || taskInDb.StatusId == 4)
            {
                TempData["ErrorMessage"] = "Το Task δεν είναι πλέον διαθέσιμο για επεξεργασία.";
                return RedirectToAction("Index", "Home");
            }

            var statuses = await _statusApi.GetStatuses(HttpContext.Session.GetString("jwtToken"));

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

        //POST ~/Task/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateAsync(UpdateTaskFormViewModel taskVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά κατά την ενημέρωση του Task.";
                return RedirectToAction("Index", "Home");
            }

            Tasks taskInDb = await _taskApi.GetTask(taskVM.Id, HttpContext.Session.GetString("jwtToken"));

            if(!CheckUpdatedStatus(taskInDb.StatusId, taskVM.StatusId))
            {
                TempData["ErrorMessage"] = "Το Task δεν μπορεί να ενημερωθεί σε προηγούμενη κατάσταση.";
                return RedirectToAction("Index", "Home");
            }

            Tasks taskUpdate = taskInDb;

            if(taskVM.StatusId == 1)
            {
                if (taskVM.Skills == null)
                {
                    TempData["ErrorMessage"] = "Πρέπει να επιλέξετε τουλάχιστον μία ικανότητα.";
                    return RedirectToAction("Index", "Home");
                }

                List<TaskSkill> skillsRequired = new List<TaskSkill>();
                foreach (var skillItem in taskVM.Skills)
                {
                    skillsRequired.Add(new TaskSkill { TaskId = taskInDb.Id , SkillId = skillItem });
                }

                taskUpdate.Name = taskVM.Name;
                taskUpdate.Description = taskVM.Description;
                taskUpdate.VolunteerNumber = taskVM.VolunteerNumber;
                taskUpdate.ExpectedStartDate = taskVM.ExpectedStartDate;
                taskUpdate.ExpectedEndDate = taskVM.ExpectedEndDate;
                taskUpdate.StatusId = taskVM.StatusId;
                taskUpdate.TasksSkills = skillsRequired;
            }

            if(taskVM.StatusId == 2)
            {
                taskUpdate.Name = taskVM.Name;
                taskUpdate.Description = taskVM.Description;
                taskUpdate.StartDate = DateTime.Now;
                taskUpdate.StatusId = taskVM.StatusId;
            }

            if(taskVM.StatusId ==  3)
            {
                taskUpdate.Name = taskVM.Name;
                taskUpdate.Description = taskVM.Description;
                taskUpdate.EndDate = DateTime.Now;
                taskUpdate.StatusId = taskVM.StatusId;
            }

            await _taskApi.UpdateTask(taskUpdate, HttpContext.Session.GetString("jwtToken"));

            TempData["SuccessMessage"] = "Το Task ενημερώθηκε με επιτυχία.";
            return RedirectToAction("Index", "Home");
        }

        //----------------------------------------------------------------------------------------//

        public async Task<bool> IsLoggedInAsync()
        {
            var userId = HttpContext.Session.GetString("userId");
            var username = HttpContext.Session.GetString("username");
            var universityId = HttpContext.Session.GetString("universityId");
            var jwtToken = HttpContext.Session.GetString("jwtToken");

            if (userId == null || username == null || universityId == null || jwtToken == null)
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

        public bool CheckUpdatedStatus(int oldStatus, int newStatus)
        {
            if (newStatus >= oldStatus)
                return true;

            if (oldStatus == 1 && newStatus == 3)
                return false;

            return false;
        }
    }
}
