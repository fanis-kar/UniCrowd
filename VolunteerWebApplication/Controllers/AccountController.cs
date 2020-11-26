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
        private readonly ISkillApi _skillApi;
        private readonly IGroupApi _groupApi;

        public AccountController(IAuthenticationApi authenticationApi, IVolunteerApi volunteerApi, ISkillApi skillApi, IGroupApi groupApi)
        {
            _authenticationApi = authenticationApi ?? throw new ArgumentNullException(nameof(authenticationApi));
            _volunteerApi = volunteerApi ?? throw new ArgumentNullException(nameof(volunteerApi));
            _skillApi = skillApi ?? throw new ArgumentNullException(nameof(skillApi));
            _groupApi = groupApi ?? throw new ArgumentNullException(nameof(groupApi));
        }

        // GET ~/Account
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var volunteerInfo = await _volunteerApi.GetVolunteer(int.Parse(HttpContext.Session.GetString("volunteerId")), HttpContext.Session.GetString("jwtToken"));
            var volunteerGroups = await _groupApi.GetVolunteerGroups(volunteerInfo.Id, HttpContext.Session.GetString("jwtToken"));

            string volunteerStars = volunteerInfo.Stars.ToString();

            if (volunteerStars == null || volunteerStars == "")
            {
                volunteerStars = "Δεν έχω βαθμολογηθεί ακόμα";
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

        // GET ~/Account/Update
        public async Task<IActionResult> UpdateAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var volunteerInfo = await _volunteerApi.GetVolunteer(int.Parse(HttpContext.Session.GetString("volunteerId")), HttpContext.Session.GetString("jwtToken"));

            UpdateVolunteerViewModel updateVolunteerViewModel = new UpdateVolunteerViewModel()
            {
                Id = volunteerInfo.Id,
                FirstName = volunteerInfo.FirstName,
                LastName = volunteerInfo.LastName,
                FatherName = volunteerInfo.FatherName,
                Phone = volunteerInfo.Phone,
                Address = volunteerInfo.Address
            };

            ViewData["jwtTokenSession"] = HttpContext.Session.GetString("jwtToken");
            return View(updateVolunteerViewModel);
        }

        // POST ~/Account/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(UpdateVolunteerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά. Παρακαλώ δοκιμάστε ξανά αργότερα.";
                return RedirectToAction("Index", "Home");
            }

            var volunteerInfo = await _volunteerApi.GetVolunteer(int.Parse(HttpContext.Session.GetString("volunteerId")), HttpContext.Session.GetString("jwtToken"));

            if (volunteerInfo == null)
            {
                TempData["ErrorMessage"] = "Ο Εθελοντής δε βρέθηκε.";
                return RedirectToAction("Index", "Home");
            }

            volunteerInfo.FirstName = model.FirstName;
            volunteerInfo.LastName = model.LastName;
            volunteerInfo.FatherName = model.FatherName;
            volunteerInfo.Phone = model.Phone;
            volunteerInfo.Address = model.Address;

            try
            {
                await _volunteerApi.UpdateVolunteer(volunteerInfo, HttpContext.Session.GetString("jwtToken"));
                await _skillApi.UpdateVolunteerSkills(volunteerInfo.Id, model.Skills.ToList(), HttpContext.Session.GetString("jwtToken"));
            }
            catch(Exception)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά. Παρακαλώ δοκιμάστε ξανά αργότερα.";
                return RedirectToAction("Index", "Home");
            }

            TempData["SuccessMessage"] = "Το Προφίλ ενημερώθηκε με επιτυχία.";
            return RedirectToAction("Index", "Home");
        }

        // GET ~/Account/Login
        public async Task<IActionResult> LoginAsync()
        {
            if (await IsLoggedInAsync())
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST ~/Account/Login
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

        // GET ~/Account/Register
        public async Task<IActionResult> RegisterAsync()
        {
            if (await IsLoggedInAsync())
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST ~/Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterVolunteerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά. Παρακαλώ δοκιμάστε ξανά αργότερα.";

                return RedirectToAction("Register", "Account");
            }

            User user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                RoleId = 2
            };

            Volunteer volunteer = new Volunteer()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                FatherName = model.FatherName,
                Phone = model.Phone,
                Address = model.Address
            };

            try
            {
                await _authenticationApi.VolunteerRegister(user);

                //---------------------------------------//

                string response = await _authenticationApi.VolunteerLogin(user);
                var resultObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);

                volunteer.AccountId = int.Parse(resultObject["userId"]);

                await _volunteerApi.AddVolunteer(volunteer, resultObject["jwtToken"]);

                //---------------------------------------//

                TempData["SuccessMessage"] = "Η Εγγραφή ολοκληρώθηκε.";
                return RedirectToAction("Login", "Account");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Η Εγγραφή δεν πραγματοποιήθηκε.";
                return RedirectToAction("Login", "Account");
            }
        }

        // GET ~/Account/Logout
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
