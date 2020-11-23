using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UniversityApiCollection.Infrastructure;
using UniversityApiCollection.Interfaces;
using Model;

namespace UniversityApiCollection
{
    public class UniversityApi : BaseHttpClientWithFactory, IUniversityApi
    {
        public UniversityApi(IHttpClientFactory factory)
            : base(factory)
        {
        }

        //-----------------------------------------//

        public async Task<List<University>> GetUniversities(string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/University")
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<List<University>>(message);
        }

        public async Task<University> GetUniversity(int universityId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/University")
                           .AddToPath(universityId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<University>(message);
        }

        public async Task<University> GetUniversityByUserId(int userId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/University/User")
                           .AddToPath(userId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<University>(message);
        }

        //-----------------------------------------//

        public async Task<Faculty> GetFaculty(int facultyId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Faculty")
                           .AddToPath(facultyId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<Faculty>(message);
        }

        //-----------------------------------------//

        public async Task<Department> GetDepartment(int departmentId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Department")
                           .AddToPath(departmentId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<Department>(message);
        }

        //-----------------------------------------//

    }
}