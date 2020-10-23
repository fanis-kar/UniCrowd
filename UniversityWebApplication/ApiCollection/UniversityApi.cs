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
    public class UniversityApi : BaseHttpClientWithFactory, IUniversityApi
    {
        public UniversityApi(IHttpClientFactory factory)
            : base(factory)
        {
        }

        public async Task<University> GetUniversity(int universityId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection();
            authorization.Add("Authorization", "Bearer " + jwtToken);

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
            NameValueCollection authorization = new NameValueCollection();
            authorization.Add("Authorization", "Bearer " + jwtToken);

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/University")
                           .AddToPath(userId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<University>(message);
        }
    }
}