using UniversityApiCollection.Infrastructure;
using UniversityApiCollection.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UniversityApiCollection
{
    public class VolunteerApi : BaseHttpClientWithFactory, IVolunteerApi
    {
        public VolunteerApi(IHttpClientFactory factory)
            : base(factory)
        {
        }

        public async Task<List<Volunteer>> GetVolunteers(string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Volunteer")
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<List<Volunteer>>(message);
        }

        public async Task<Volunteer> GetVolunteer(int volunteerId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Volunteer")
                           .AddToPath(volunteerId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<Volunteer>(message);
        }

        public async Task<Volunteer> GetVolunteerByUserId(int userId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Volunteer/User")
                           .AddToPath(userId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<Volunteer>(message);
        }
    }
}
