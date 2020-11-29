using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ApiCollection.Interfaces;
using UniversityWebApplication.Models;
using Model.Report;

namespace UniversityWebApplication.Controllers
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

                if(taskTemp.UniversityId == int.Parse(HttpContext.Session.GetString("universityId")))
                {
                    universitiesReportsListViewModel.Add(new UniversitiesReportsListViewModel { Id = report.Id, Title = report.Title, TaskId = taskTemp.Id, TaskName = taskTemp.Name });
                }
            }

            return View(universitiesReportsListViewModel);
        }

        // GET ~/UniversityReport/All
        public async Task<IActionResult> AllAsync()
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

        //GET ~/UniversityReport/New/{id}
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

            if (taskInDb.UniversityId != int.Parse(HttpContext.Session.GetString("universityId")))
            {
                TempData["ErrorMessage"] = "Δεν μπορείς να συντάξεις Report για αυτό το Task.";
                return RedirectToAction("Index", "Home");
            }

            NewUniversityReportViewModel newUniversityReportViewModel = new NewUniversityReportViewModel()
            {
                TaskId = id
            };

            return View("New", newUniversityReportViewModel);
        }

        //POST ~/UniversityReport/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewAsync(NewUniversityReportViewModel reportVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά κατά τη δημιουργία του Report.";
                return RedirectToAction("Index", "Home");
            }

            UniversityReport report = new UniversityReport
            {
                Title = reportVM.Title,
                Content = reportVM.Content,
                Created = DateTime.Now,
                TaskId = reportVM.TaskId
            };

            await _universityReportApi.AddUniversityReport(report, HttpContext.Session.GetString("jwtToken"));

            TempData["SuccessMessage"] = "Το Report δημιουργήθηκε με επιτυχία.";
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
    }
}
