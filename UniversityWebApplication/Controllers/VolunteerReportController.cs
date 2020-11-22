using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ApiCollection;
using ApiCollection.Interfaces;
using UniversityWebApplication.Models;
using Model.Report;

namespace UniversityWebApplication.Controllers
{
    public class VolunteerReportController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IUniversityApi _universityApi;
        private readonly ITaskApi _taskApi;
        private readonly IVolunteerReportApi _volunteerReportApi;

        public VolunteerReportController(IAuthenticationApi authenticationApi, IUniversityApi universityApi, ITaskApi taskApi, IVolunteerReportApi volunteerReportApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _universityApi = universityApi ?? throw new ArgumentNullException(nameof(universityApi));
            _taskApi = taskApi ?? throw new ArgumentNullException(nameof(taskApi));
            _volunteerReportApi = volunteerReportApi ?? throw new ArgumentNullException(nameof(volunteerReportApi));
        }

        // ~/VolunteerReport
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var reports = await _volunteerReportApi.GetVolunteersReports(HttpContext.Session.GetString("jwtToken"));

            List<VolunteersReportsListViewModel> volunteersReportsListViewModel = new List<VolunteersReportsListViewModel>();

            foreach (var report in reports)
            {
                var taskTemp = await _taskApi.GetTask(report.TaskId, HttpContext.Session.GetString("jwtToken"));

                if(taskTemp.UniversityId == int.Parse(HttpContext.Session.GetString("universityId")))
                {
                    volunteersReportsListViewModel.Add(new VolunteersReportsListViewModel { Id = report.Id, Title = report.Title, TaskId = taskTemp.Id, TaskName = taskTemp.Name });
                }
            }

            return View(volunteersReportsListViewModel);
        }

        // ~/VolunteerReport/All
        public async Task<IActionResult> AllAsync()
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

        // ~/VolunteerReport/Task/{id}
        public async Task<IActionResult> TaskAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var taskInfo = await _taskApi.GetTask(id, HttpContext.Session.GetString("jwtToken"));
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

        // ~/VolunteerReport/Details/{id}
        public async Task<IActionResult> DetailsAsync(string id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var report = await _volunteerReportApi.GetVolunteerReport(id, HttpContext.Session.GetString("jwtToken"));
            var task = await _taskApi.GetTask(report.TaskId, HttpContext.Session.GetString("jwtToken"));

            if (report == null)
            {
                TempData["ErrorMessage"] = "Το Report δε βρέθηκε.";
                return RedirectToAction("Index", "Home");
            }

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
    }
}
