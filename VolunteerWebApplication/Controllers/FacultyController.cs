using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiCollection.Interfaces;

namespace VolunteerWebApplication.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IUniversityApi _universityApi;

        public FacultyController(IAuthenticationApi authenticationApi, IUniversityApi universityApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _universityApi = universityApi ?? throw new ArgumentNullException(nameof(universityApi));
        }

        // GET ~/Faculty/Details/{id}
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var facultyInfo = await _universityApi.GetFaculty(id, HttpContext.Session.GetString("jwtToken"));

            return View(facultyInfo);
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
