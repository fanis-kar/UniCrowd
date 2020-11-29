using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiCollection.Interfaces;
using VolunteerWebApplication.Models;
using Model;
using Model.Report;

namespace VolunteerWebApplication.Controllers
{
    public class VolunteerReportController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly ITaskApi _taskApi;
        private readonly IGroupApi _groupApi;
        private readonly IVolunteerReportApi _volunteerReportApi;

        public VolunteerReportController(IAuthenticationApi authenticationApi, ITaskApi taskApi, IGroupApi groupApi, IVolunteerReportApi volunteerReportApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _taskApi = taskApi ?? throw new ArgumentNullException(nameof(taskApi));
            _groupApi = groupApi ?? throw new ArgumentNullException(nameof(groupApi));
            _volunteerReportApi = volunteerReportApi ?? throw new ArgumentNullException(nameof(volunteerReportApi));
        }

        // GET ~/VolunteerReport
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var reports = await _volunteerReportApi.GetVolunteersReports(HttpContext.Session.GetString("jwtToken"));

            List<VolunteersReportsListViewModel> volunteersReportsListViewModel = new List<VolunteersReportsListViewModel>();

            foreach (var report in reports)
            {
                var taskTemp = await _taskApi.GetTask(report.TaskId, HttpContext.Session.GetString("jwtToken"));

                volunteersReportsListViewModel.Add(new VolunteersReportsListViewModel { Id = report.Id, Title = report.Title, TaskId = taskTemp.Id, TaskName = taskTemp.Name });
            }

            return View(volunteersReportsListViewModel);
        }

        // GET  ~/VolunteerReport/Task/{id}
        public async Task<IActionResult> TaskAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var taskInfo = await _taskApi.GetTask(id, HttpContext.Session.GetString("jwtToken"));

            if (taskInfo == null)
            {
                TempData["ErrorMessage"] = "Το Task δε βρέθηκε.";
                return RedirectToAction("Index", "Home");
            }

            var reports = await _volunteerReportApi.GetVolunteersReports(HttpContext.Session.GetString("jwtToken"));

            List<VolunteersReportsListViewModel> volunteersReportsListViewModel = new List<VolunteersReportsListViewModel>();

            foreach (var report in reports)
            {
                if (report.TaskId == taskInfo.Id)
                {
                    volunteersReportsListViewModel.Add(new VolunteersReportsListViewModel { Id = report.Id, Title = report.Title, TaskId = taskInfo.Id, TaskName = taskInfo.Name });
                }
            }

            return View("Task", volunteersReportsListViewModel);
        }

        // GET  ~/VolunteerReport/Details/{id}
        public async Task<IActionResult> DetailsAsync(string id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var report = await _volunteerReportApi.GetVolunteerReport(id, HttpContext.Session.GetString("jwtToken"));

            if (report == null)
            {
                TempData["ErrorMessage"] = "Το Report δε βρέθηκε.";
                return RedirectToAction("Index", "Home");
            }

            var task = await _taskApi.GetTask(report.TaskId, HttpContext.Session.GetString("jwtToken"));

            VolunteerReportDetailsViewModel volunteerReportDetailsViewModel = new VolunteerReportDetailsViewModel()
            {
                Id = report.Id,
                Title = report.Title,
                Content = report.Content,
                Created = report.Created,
                TaskId = task.Id,
                TaskName = task.Name
            };

            return View(volunteerReportDetailsViewModel);
        }

        //GET ~/VolunteerReport/New/{id}
        public async Task<ActionResult> NewAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            Tasks taskInDb = await _taskApi.GetTask(id, HttpContext.Session.GetString("jwtToken"));

            if (taskInDb == null)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά.";
                return RedirectToAction("Index", "Home");
            }

            bool flag = false;

            var myGroups = await _groupApi.GetVolunteerGroups(int.Parse(HttpContext.Session.GetString("volunteerId")), HttpContext.Session.GetString("jwtToken"));
            List<Tasks> myTasks = new List<Tasks>();

            foreach (var group in myGroups)
            {
                if (group.Task.Id == id)
                    flag = true;
            }

            if (!flag)
            {
                TempData["ErrorMessage"] = "Δεν μπορείς να συντάξεις Report για αυτό το Task.";
                return RedirectToAction("Index", "Home");
            }

            NewVolunteerReportViewModel newVolunteerReportViewModel = new NewVolunteerReportViewModel()
            {
                TaskId = id
            };

            return View("New", newVolunteerReportViewModel);
        }

        //POST ~/VolunteerReport/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewAsync(NewVolunteerReportViewModel reportVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά κατά τη δημιουργία του Report.";
                return RedirectToAction("Index", "Home");
            }

            VolunteerReport report = new VolunteerReport
            {
                Title = reportVM.Title,
                Content = reportVM.Content,
                Created = DateTime.Now,
                TaskId = reportVM.TaskId
            };

            await _volunteerReportApi.AddVolunteerReport(report, HttpContext.Session.GetString("jwtToken"));

            TempData["SuccessMessage"] = "Το Report δημιουργήθηκε με επιτυχία.";
            return RedirectToAction("Index", "Home");
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
    }
}
