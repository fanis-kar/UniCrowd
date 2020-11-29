using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ApiCollection.Interfaces;
using VolunteerWebApplication.Models;

namespace UniversityWebApplication.Controllers
{
    public class TaskController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IVolunteerApi _volunteerApi;
        private readonly ITaskApi _taskApi;
        private readonly IGroupApi _groupApi;
        private readonly IInvitationApi _invitationApi;

        public TaskController(IAuthenticationApi authenticationApi, IVolunteerApi volunteerApi, ITaskApi taskApi, IGroupApi groupApi, IInvitationApi invitationApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _volunteerApi = volunteerApi ?? throw new ArgumentNullException(nameof(volunteerApi));
            _taskApi = taskApi ?? throw new ArgumentNullException(nameof(taskApi));
            _groupApi = groupApi ?? throw new ArgumentNullException(nameof(groupApi));
            _invitationApi = invitationApi ?? throw new ArgumentNullException(nameof(invitationApi));
        }

        // GET ~/Task
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var myGroups = await _groupApi.GetVolunteerGroups(int.Parse(HttpContext.Session.GetString("volunteerId")), HttpContext.Session.GetString("jwtToken"));
            List<Tasks> myTasks = new List<Tasks>();

            foreach(var group in myGroups)
            {
                myTasks.Add(group.Task);
            }

            return View(myTasks);
        }

        // GET ~/Task/All
        public async Task<IActionResult> AllAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            List<TasksListViewModel> tasksList = new List<TasksListViewModel>();

            var tasks = await _taskApi.GetTasks(HttpContext.Session.GetString("jwtToken"));

            foreach(var task in tasks)
            {
                var invitationsByTask = await _invitationApi.GetInvitationsByTaskId(task.Id, HttpContext.Session.GetString("jwtToken"));
                bool checkInvite = false;

                foreach(var invitation in invitationsByTask)
                {
                    if(invitation.VolunteerId == int.Parse(HttpContext.Session.GetString("volunteerId")))
                    {
                        checkInvite = true;
                    }
                }

                tasksList.Add(new TasksListViewModel { Task = task, CheckInvite = checkInvite });
            }

            return View(tasksList);
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

        //----------------------------------------------------------------------------------------//

        public async Task<bool> IsLoggedInAsync()
        {
            var userId = HttpContext.Session.GetString("userId");
            var username = HttpContext.Session.GetString("username");
            var volunteerId = HttpContext.Session.GetString("volunteerId");
            var jwtToken = HttpContext.Session.GetString("jwtToken");

            if (userId == null || username == null || volunteerId == null || jwtToken == null)
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
