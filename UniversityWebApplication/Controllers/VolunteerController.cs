using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityWebApplication.ApiCollection.Interfaces;

namespace UniversityWebApplication.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IVolunteerApi _volunteerApi;

        public VolunteerController(IAuthenticationApi authenticationApi, IVolunteerApi volunteerApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _volunteerApi = volunteerApi ?? throw new ArgumentNullException(nameof(volunteerApi));
        }

        // ~/Volunteer
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var volunteers = await _volunteerApi.GetVolunteers(HttpContext.Session.GetString("jwtToken"));

            return View(volunteers);
        }

        // ~/Volunteer/Details/{id}
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var volunteerInfo = await _volunteerApi.GetVolunteer(id, HttpContext.Session.GetString("jwtToken"));

            return View(volunteerInfo);
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
