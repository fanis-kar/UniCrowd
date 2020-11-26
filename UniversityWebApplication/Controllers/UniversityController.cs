using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiCollection.Interfaces;

namespace UniversityWebApplication.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IUniversityApi _universityApi;

        public UniversityController(IAuthenticationApi authenticationApi, IUniversityApi universityApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _universityApi = universityApi ?? throw new ArgumentNullException(nameof(universityApi));
        }

        // GET ~/University
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var universities = await _universityApi.GetUniversities(HttpContext.Session.GetString("jwtToken"));

            return View(universities);
        }

        // GET ~/University/Details/{id}
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var universityInfo = await _universityApi.GetUniversity(id, HttpContext.Session.GetString("jwtToken"));

            return View(universityInfo);
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
