using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Task;
using UniversityWebApplication.ApiCollection;
using UniversityWebApplication.ApiCollection.Interfaces;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.Controllers
{
    public class GroupController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IUniversityApi _universityApi;
        private readonly IVolunteerApi _volunteerApi;
        private readonly IGroupApi _groupApi;
        private readonly ITaskApi _taskApi;
        private readonly IInvitationApi _invitationApi;
        private readonly ISkillApi _skillApi;

        public GroupController(IAuthenticationApi authenticationApi, IUniversityApi universityApi, IVolunteerApi volunteerApi, IGroupApi groupApi, ISkillApi skillApi, IStatusApi statusApi, ITaskApi taskApi, IInvitationApi invitationApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _universityApi = universityApi ?? throw new ArgumentNullException(nameof(universityApi));
            _volunteerApi = volunteerApi ?? throw new ArgumentNullException(nameof(volunteerApi));
            _groupApi = groupApi ?? throw new ArgumentNullException(nameof(groupApi));
            _taskApi = taskApi ?? throw new ArgumentNullException(nameof(taskApi));
            _invitationApi = invitationApi ?? throw new ArgumentNullException(nameof(invitationApi));
            _skillApi = skillApi ?? throw new ArgumentNullException(nameof(skillApi));
        }

        // ~/Group
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var groups = await _groupApi.GetGroups(HttpContext.Session.GetString("jwtToken"));

            return View(groups);
        }

        // ~/Group/Details/{id}
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            List<Volunteer> volunteers = new List<Volunteer>();

            var groupInfo = await _groupApi.GetGroup(id, HttpContext.Session.GetString("jwtToken"));
            var universityInfo = await _universityApi.GetUniversity(groupInfo.Task.UniversityId, HttpContext.Session.GetString("jwtToken"));

            if (groupInfo.VolunteersGroups.Count() > 0)
            {
                foreach (var volunteer in groupInfo.VolunteersGroups)
                {
                    volunteers.Add(await _volunteerApi.GetVolunteer(volunteer.VolunteerId, HttpContext.Session.GetString("jwtToken")));
                }
            }

            GroupDetailsViewModel groupDetailsViewModel = new GroupDetailsViewModel()
            {
                Group = groupInfo,
                University = universityInfo,
                Volunteers = volunteers
            };

            return View(groupDetailsViewModel);
        }

        // ~/Group/Manage/{id}
        public async Task<IActionResult> Manage(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var groupInfo = await _groupApi.GetGroup(id, HttpContext.Session.GetString("jwtToken"));

            if (groupInfo == null)
            {
                TempData["ErrorMessage"] = "Το Group δε βρέθηκε.";
                return RedirectToAction("Index", "Home");
            }

            var taskInfo = await _taskApi.GetTask(groupInfo.TaskId, HttpContext.Session.GetString("jwtToken"));

            if (taskInfo.UniversityId.ToString() != HttpContext.Session.GetString("universityId"))
            {
                TempData["ErrorMessage"] = "Δεν είσαι υπεύθυνος του Group";
                return RedirectToAction("Index", "Home");
            }

            if (taskInfo.StatusId != 1)
            {
                TempData["ErrorMessage"] = "Δεν μπορείς να διαχειριστείς το Group σε αυτό το στάδιο.";
                return RedirectToAction("Index", "Home");
            }

            List<Invitation> invitations = await _invitationApi.GetInvitationsByTaskId(taskInfo.Id, HttpContext.Session.GetString("jwtToken"));
            List<InvitationsListViewModel> invitationsListViewModels = new List<InvitationsListViewModel>();

            foreach (var invitation in invitations)
            {
                Volunteer volunteer = await _volunteerApi.GetVolunteer(invitation.VolunteerId, HttpContext.Session.GetString("jwtToken"));

                if(invitation.Decision == null)
                {
                    invitation.Decision = false;
                }

                invitationsListViewModels.Add(new InvitationsListViewModel { InvitationId = invitation.Id, VolunteerId = volunteer.Id, FullName = volunteer.FullName, SkillsHave = await GetSkillsHaveAsync(taskInfo.Id, volunteer.Id), SkillsRequired = await GetSkillsRequiredAsync(taskInfo.Id), Date = invitation.Created, Response = (bool)invitation.Decision });
            }

            ManageGroupViewModel manageGroupViewModel = new ManageGroupViewModel()
            {
                Id = id,
                Name = groupInfo.Name,
                Stars = (int)groupInfo.Stars,
                Invitations = invitationsListViewModels
            };

            return View(manageGroupViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageGroupViewModel groupVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά κατά τη διαχείριση του Group.";
                return RedirectToAction("Index", "Home");
            }

            Group groupInDb = await _groupApi.GetGroup(groupVM.Id, HttpContext.Session.GetString("jwtToken"));

            Group groupUpdate = groupInDb;
            groupUpdate.Name = groupVM.Name;
            groupUpdate.Stars = groupVM.Stars;
            groupUpdate.VolunteersGroups.Clear();

            foreach (var invitation in groupVM.Invitations)
            {
                Invitation invitationTemp = await _invitationApi.GetInvitation(invitation.InvitationId, HttpContext.Session.GetString("jwtToken"));
                invitationTemp.Decision = invitation.Response;
                await _invitationApi.UpdateInvitation(invitationTemp, HttpContext.Session.GetString("jwtToken"));

                if (invitation.Response)
                {
                    groupUpdate.VolunteersGroups.Add(new VolunteerGroup { GroupId = groupUpdate.Id, VolunteerId = groupUpdate.Task.Invitations.Where(i => i.Id == invitation.InvitationId).FirstOrDefault().VolunteerId });
                }
            }

            await _groupApi.UpdateGroup(groupUpdate, HttpContext.Session.GetString("jwtToken"));

            TempData["SuccessMessage"] = "Το Group ενημερώθηκε με επιτυχία.";
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

        public async Task<string> GetCurrentVolunteersAsync(int groupId)
        {
            var groupInfo = await _groupApi.GetGroup(groupId, HttpContext.Session.GetString("jwtToken"));

            string volunteers = "[ ";

            if (groupInfo.VolunteersGroups != null && groupInfo.VolunteersGroups.Count() > 0)
            {
                foreach (var volunteer in groupInfo.VolunteersGroups)
                {
                    var volunteerInfo = await _volunteerApi.GetVolunteer(volunteer.VolunteerId, HttpContext.Session.GetString("jwtToken"));

                    volunteers = volunteers + "\"" + volunteerInfo.Id.ToString() + "\", ";
                }

                int index = volunteers.LastIndexOf(',');
                volunteers = volunteers.Remove(index, 1);
            }

            volunteers += "]";

            return volunteers;
        }

        public async Task<int> GetSkillsRequiredAsync(int taskId)
        {
            var taskInfo = await _taskApi.GetTask(taskId, HttpContext.Session.GetString("jwtToken"));
            return taskInfo.TasksSkills.Where(ts => ts.TaskId == taskId).Count();
        }

        public async Task<int> GetSkillsHaveAsync(int taskId, int volunteerId)
        {
            var taskInfo = await _taskApi.GetTask(taskId, HttpContext.Session.GetString("jwtToken"));
            var taskSkills = taskInfo.TasksSkills.Where(ts => ts.TaskId == taskId).Select(ts => ts.SkillId).ToList();

            var skillsInfo = await _skillApi.GetVolunteerSkills(volunteerId, HttpContext.Session.GetString("jwtToken"));
            var volunteerSkills = skillsInfo.Select(ts => ts.Id).ToList();

            int result = taskSkills.Intersect(volunteerSkills).Count();

            return result;
        }
    }
}
