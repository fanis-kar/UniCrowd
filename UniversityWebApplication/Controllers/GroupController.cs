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
    public class GroupController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IUniversityApi _universityApi;
        private readonly IVolunteerApi _volunteerApi;
        private readonly IGroupApi _groupApi;

        public GroupController(IAuthenticationApi authenticationApi, IUniversityApi universityApi, IVolunteerApi volunteerApi, IGroupApi groupApi, ISkillApi skillApi, IStatusApi statusApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _universityApi = universityApi ?? throw new ArgumentNullException(nameof(universityApi));
            _volunteerApi = volunteerApi ?? throw new ArgumentNullException(nameof(volunteerApi));
            _groupApi = groupApi ?? throw new ArgumentNullException(nameof(groupApi));
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
