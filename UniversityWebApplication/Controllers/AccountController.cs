using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ApiCollection.Interfaces;
using UniversityWebApplication.Models;
using System.Net.Http.Formatting;
using System.Collections;
using Model;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IUniversityApi _universityApi;

        public AccountController(IAuthenticationApi authenticationApi, IUniversityApi universityApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _universityApi = universityApi ?? throw new ArgumentNullException(nameof(universityApi));
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (! await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var universityInfo = await _universityApi.GetUniversityByUserId(int.Parse(HttpContext.Session.GetString("userId")), HttpContext.Session.GetString("jwtToken"));

            return View(universityInfo);
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

            string response = await _authenticationApi.Login(user);

            try
            {
                var resultObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                University university = await _universityApi.GetUniversityByUserId(Int32.Parse(resultObject["userId"]), resultObject["jwtToken"]);

                HttpContext.Session.SetString("userId", resultObject["userId"]);
                HttpContext.Session.SetString("username", model.Username);
                HttpContext.Session.SetString("universityId", university.Id.ToString());
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
            HttpContext.Session.Remove("universityId");
            HttpContext.Session.Remove("jwtToken");

            TempData["SuccessMessage"] = "Αποσυνδέθηκες με επιτυχία.";

            return RedirectToAction("Login", "Account");
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
