using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniversityWebApplication.ApiCollection.Interfaces;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyApi _facultyApi;

        public FacultyController(IFacultyApi facultyApi)
        {
            _facultyApi = facultyApi ?? throw new ArgumentNullException(nameof(facultyApi));
        }

        // ~/Faculty/Details/{id}
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (!await IsLoggedInAsync())
                return RedirectToAction("Login", "Account");

            var facultyInfo = await _facultyApi.GetFaculty(id, HttpContext.Session.GetString("jwtToken"));

            return View(facultyInfo);
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
