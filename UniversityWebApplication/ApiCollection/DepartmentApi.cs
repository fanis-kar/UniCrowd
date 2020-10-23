using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UniversityWebApplication.ApiCollection.Infrastructure;
using UniversityWebApplication.ApiCollection.Interfaces;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.ApiCollection
{
    public class FacultyApi : BaseHttpClientWithFactory, IFacultyApi
    {
        public FacultyApi(IHttpClientFactory factory)
            : base(factory)
        {
        }

        public async Task<Faculty> GetFaculty(int facultyId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection();
            authorization.Add("Authorization", "Bearer " + jwtToken);

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Faculty")
                           .AddToPath(facultyId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<Faculty>(message);
        }
    }
}