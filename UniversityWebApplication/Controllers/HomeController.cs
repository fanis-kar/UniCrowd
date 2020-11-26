using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiCollection.Interfaces;

namespace UniversityWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;

        public HomeController(IAuthenticationApi authenticationApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
        }

        // GET ~/Home/Index
        public async Task<IActionResult> IndexAsync()
        {
            if (! await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            return View();
        }

        // GET ~/Home/About
        public IActionResult About()
        {
            return View();
        }

        // GET ~/Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
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
