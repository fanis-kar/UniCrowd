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
using UniversityWebApplication.Models;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginForm model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error_message = "Κάτι πήγε στραβά. Παρακαλώ δοκιμάστε ξανά αργότερα.";

                return RedirectToAction("Login", "Account");
            }

            var url = "https://localhost:44378/authentication/login?d=university-area";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                LoginForm body = new LoginForm()
                {
                    Username = model.Username,
                    Password = model.Password
                };

                string json = JsonConvert.SerializeObject(body);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();

                    HttpContext.Session.SetString("jwt_token", strResult);
                    HttpContext.Session.SetString("username", model.Username);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error_message = "Λάθος στοιχεία εισόδου.";

                    return RedirectToAction("Login", "Account");
                }
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("jwt_token");
            HttpContext.Session.Remove("username");

            ViewBag.success_message = "Αποσυνδέθηκες με επιτυχία.";

            return RedirectToAction("Login", "Account");
        }
    }
}
