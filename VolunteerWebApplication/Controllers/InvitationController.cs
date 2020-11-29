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
    public class InvitationController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly ITaskApi _taskApi;
        private readonly IGroupApi _groupApi;
        private readonly IVolunteerReportApi _volunteerReportApi;
        private readonly IInvitationApi _invitationApi;

        public InvitationController(IAuthenticationApi authenticationApi, ITaskApi taskApi, IGroupApi groupApi, IVolunteerReportApi volunteerReportApi, IInvitationApi invitationApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _taskApi = taskApi ?? throw new ArgumentNullException(nameof(taskApi));
            _groupApi = groupApi ?? throw new ArgumentNullException(nameof(groupApi));
            _volunteerReportApi = volunteerReportApi ?? throw new ArgumentNullException(nameof(volunteerReportApi));
            _invitationApi = invitationApi ?? throw new ArgumentNullException(nameof(invitationApi));
        }

        // GET  ~/Invitation/Task/{id}
        public async Task<IActionResult> TaskAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var taskInfo = await _taskApi.GetTask(id, HttpContext.Session.GetString("jwtToken"));

            if(taskInfo == null || taskInfo.StatusId != 1)
            {
                TempData["ErrorMessage"] = "Δεν μπορείς να συμμετάσχεις σε αυτό το Task.";
                return RedirectToAction("Index", "Home");
            }

            var invitationsByTask = await _invitationApi.GetInvitationsByTaskId(taskInfo.Id, HttpContext.Session.GetString("jwtToken"));
            bool checkInvite = false;

            foreach (var invitation in invitationsByTask)
            {
                if (invitation.VolunteerId == int.Parse(HttpContext.Session.GetString("volunteerId")))
                {
                    checkInvite = true;
                }
            }

            if(checkInvite)
            {
                TempData["ErrorMessage"] = "Έχεις στείλει ήδη πρόσκληση.";
                return RedirectToAction("Index", "Home");
            }

            NewInvitationViewModel newInvitationViewModel = new NewInvitationViewModel
            {
                TaskId = taskInfo.Id
            };

            return View("Task", newInvitationViewModel);
        }

        //POST ~/Invitation/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveAsync(NewInvitationViewModel invitationVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά κατά την αποστολή πρόσκλησης.";
                return RedirectToAction("Index", "Home");
            }

            Invitation invitation = new Invitation
            {
                Title = invitationVM.Title,
                Description = invitationVM.Description,
                Created = DateTime.Now,
                TaskId = invitationVM.TaskId,
                VolunteerId = int.Parse(HttpContext.Session.GetString("volunteerId"))
            };

            await _invitationApi.AddInvitation(invitation, HttpContext.Session.GetString("jwtToken"));

            TempData["SuccessMessage"] = "Η πρόσκληση στάλθηκε.";
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
