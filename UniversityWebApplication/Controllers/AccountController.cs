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
using UniversityWebApplication.ApiCollection.Interfaces;
using UniversityWebApplication.Models;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUniversityApi _universityApi;

        public AccountController(IUniversityApi universityApi)
        {
            _universityApi = universityApi ?? throw new ArgumentNullException(nameof(universityApi));
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (! await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            int userId = int.Parse(HttpContext.Session.GetString("userId"));
            var universityInfo = await _universityApi.GetUniversityByUserId(userId, HttpContext.Session.GetString("jwtToken"));

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
        public async Task<IActionResult> LoginAsync(LoginForm model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά. Παρακαλώ δοκιμάστε ξανά αργότερα.";

                return RedirectToAction("Login", "Account");
            }

            var url = "https://localhost:44378/authentication/login?destination=university-area";

            using var client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            LoginForm body = new LoginForm()
            {
                Username = model.Username,
                Password = model.Password
            };

            string json = JsonConvert.SerializeObject(body);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, httpContent);
            string strResult = await response.Content.ReadAsStringAsync();
            var resultObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(strResult);

            if (response.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString("userId", resultObject["userId"]);
                HttpContext.Session.SetString("username", model.Username);
                HttpContext.Session.SetString("jwtToken", resultObject["jwtToken"]);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = strResult;

                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("jwt_token");
            HttpContext.Session.Remove("username");

            TempData["SuccessMessage"] = "Αποσυνδέθηκες με επιτυχία.";

            return RedirectToAction("Login", "Account");
        }

        //----------------------------------------------------------------------------------------//

        public async Task<bool> IsLoggedInAsync()
        {
            var username = HttpContext.Session.GetString("username");
            var userId = HttpContext.Session.GetString("userId");
            var jwtToken = HttpContext.Session.GetString("jwtToken");

            if (username == null || userId == null || jwtToken == null)
            {
                return false;
            }

            var url = "https://localhost:44378/authentication/validate?userId=" + userId + "&jwtToken=" + jwtToken;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);
                string strResult = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    if (userId == strResult)
                        return true;
                }
                else
                {
                    //TempData["ErrorMessage"] = strResult;

                    return false;
                }
            }

            return true;
        }
    }
}
