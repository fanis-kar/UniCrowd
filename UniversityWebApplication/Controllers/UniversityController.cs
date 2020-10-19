﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.Controllers
{
    public class UniversityController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var url = "https://localhost:44378/University";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("jwtToken"));

                HttpResponseMessage response = await client.GetAsync(url);
                string strResult = await response.Content.ReadAsStringAsync();

                TempData["Response"] = strResult;

                if (response.IsSuccessStatusCode)
                {
                    //List<University> universities = new List<University>
                    //{

                    //};

                    List<University> x = JsonConvert.DeserializeObject<List<University>>(strResult);

                    return View(x);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
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
                    //ViewData["ErrorMessage"] = strResult;

                    return false;
                }
            }

            return true;
        }
    }
}
