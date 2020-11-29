using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ApiCollection.Interfaces;
using VolunteerWebApplication.Models;
using Model.Report;

namespace VolunteerWebApplication.Controllers
{
    public class UniversityReportController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly ITaskApi _taskApi;
        private readonly IUniversityReportApi _universityReportApi;

        public UniversityReportController(IAuthenticationApi authenticationApi, ITaskApi taskApi, IUniversityReportApi universityReportApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _taskApi = taskApi ?? throw new ArgumentNullException(nameof(taskApi));
            _universityReportApi = universityReportApi ?? throw new ArgumentNullException(nameof(universityReportApi));
        }

        // GET ~/UniversityReport
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var reports = await _universityReportApi.GetUniversitiesReports(HttpContext.Session.GetString("jwtToken"));

            List<UniversitiesReportsListViewModel> universitiesReportsListViewModel = new List<UniversitiesReportsListViewModel>();

            foreach (var report in reports)
            {
                var taskTemp = await _taskApi.GetTask(report.TaskId, HttpContext.Session.GetString("jwtToken"));

                universitiesReportsListViewModel.Add(new UniversitiesReportsListViewModel { Id = report.Id, Title = report.Title, TaskId = taskTemp.Id, TaskName = taskTemp.Name });
            }

            return View(universitiesReportsListViewModel);
        }

        // GET ~/UniversityReport/Task/{id}
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

            var reports = await _universityReportApi.GetUniversitiesReports(HttpContext.Session.GetString("jwtToken"));

            List<UniversitiesReportsListViewModel> universitiesReportsListViewModel = new List<UniversitiesReportsListViewModel>();

            foreach (var report in reports)
            {
                if(report.TaskId == taskInfo.Id)
                {
                    universitiesReportsListViewModel.Add(new UniversitiesReportsListViewModel { Id = report.Id, Title = report.Title, TaskId = taskInfo.Id, TaskName = taskInfo.Name });
                }    
            }

            return View("Task", universitiesReportsListViewModel);
        }

        // GET ~/UniversityReport/Details/{id}
        public async Task<IActionResult> DetailsAsync(string id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var report = await _universityReportApi.GetUniversityReport(id, HttpContext.Session.GetString("jwtToken"));

            if (report == null)
            {
                TempData["ErrorMessage"] = "Το Report δε βρέθηκε.";
                return RedirectToAction("Index", "Home");
            }

            var task = await _taskApi.GetTask(report.TaskId, HttpContext.Session.GetString("jwtToken"));

            UniversityReportDetailsViewModel universityReportDetailsViewModel = new UniversityReportDetailsViewModel()
            {
                Id = report.Id,
                Title = report.Title,
                Content = report.Content,
                Created = report.Created,
                TaskId = task.Id,
                TaskName = task.Name
            };

            return View(universityReportDetailsViewModel);
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
