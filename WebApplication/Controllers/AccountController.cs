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
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        const string SessionName = "_JwtToken";
        const string SessionAge = "_Age";

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
                TempData["ErrorMessage"] = "Κάτι πήγε στραβά. Παρακαλώ δοκιμάστε ξανά αργότερα.";

                return RedirectToAction("Login", "Account");
            }

            var url = "https://localhost:44300/authentication/login";

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

                    HttpContext.Session.SetString(SessionName, strResult);
                    HttpContext.Session.SetInt32(SessionAge, 168); // 1 week

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
