using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiCollection.Interfaces;
using VolunteerWebApplication.Models;

namespace VolunteerWebApplication.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IVolunteerApi _volunteerApi;
        private readonly IGroupApi _groupApi;

        public VolunteerController(IAuthenticationApi authenticationApi, IVolunteerApi volunteerApi, IGroupApi groupApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _volunteerApi = volunteerApi ?? throw new ArgumentNullException(nameof(volunteerApi));
            _groupApi = groupApi ?? throw new ArgumentNullException(nameof(groupApi));
        }

        // GET ~/Volunteer
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var volunteers = await _volunteerApi.GetVolunteers(HttpContext.Session.GetString("jwtToken"));

            return View(volunteers);
        }

        // GET ~/Volunteer/Details/{id}
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var volunteerInfo = await _volunteerApi.GetVolunteer(id, HttpContext.Session.GetString("jwtToken"));
            var volunteerGroups = await _groupApi.GetVolunteerGroups(id, HttpContext.Session.GetString("jwtToken"));

            string volunteerStars = volunteerInfo.Stars.ToString();

            if (volunteerStars == null || volunteerStars == "")
            {
                volunteerStars = "Δεν έχει βαθμολογηθεί ακόμα";
            }
           
            VolunteerDetailsViewModel volunteerDetailsViewModel = new VolunteerDetailsViewModel()
            {
                Id = volunteerInfo.Id,
                FirstName = volunteerInfo.FirstName,
                LastName = volunteerInfo.LastName,
                FatherName = volunteerInfo.FatherName,
                Phone = volunteerInfo.Phone,
                Address = volunteerInfo.Address,
                Stars = volunteerStars,
                Groups = volunteerGroups
            };

            ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");
            return View(volunteerDetailsViewModel);
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
