using ApiCollection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerWebApplication.Models;

namespace VolunteerWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IVolunteerApi _volunteerApi;

        public AccountController(IAuthenticationApi authenticationApi, IVolunteerApi volunteerApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _volunteerApi = volunteerApi ?? throw new ArgumentNullException(nameof(volunteerApi));
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var volunteerInfo = await _volunteerApi.GetVolunteer(int.Parse(HttpContext.Session.GetString("volunteerId")), HttpContext.Session.GetString("jwtToken"));

            return View(volunteerInfo);
        }

        public async Task<IActionResult> LoginAsync()
        {
            if (await IsLoggedInAsync())
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά. Παρακαλώ δοκιμάστε ξανά αργότερα.";

                return RedirectToAction("Login", "Account");
            }

            User user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };

            string response = await _authenticationApi.VolunteerLogin(user);

            try
            {
                var resultObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                Volunteer volunteer = await _volunteerApi.GetVolunteerByUserId(int.Parse(resultObject["userId"]), resultObject["jwtToken"]);

                HttpContext.Session.SetString("userId", resultObject["userId"]);
                HttpContext.Session.SetString("username", model.Username);
                HttpContext.Session.SetString("volunteerId", volunteer.Id.ToString());
                HttpContext.Session.SetString("jwtToken", resultObject["jwtToken"]);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = response;
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("volunteerId");
            HttpContext.Session.Remove("jwtToken");

            TempData["SuccessMessage"] = "Αποσυνδέθηκες με επιτυχία.";

            return RedirectToAction("Login", "Account");
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
