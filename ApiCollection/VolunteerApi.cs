using ApiCollection.Infrastructure;
using ApiCollection.Interfaces;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiCollection
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

        public async Task<string> UpdateVolunteer(Volunteer volunteer, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Volunteer/Update")
                           .HttpMethod(HttpMethod.Post)
                           .Headers(authorization)
                           .GetHttpMessage();

            var json = JsonConvert.SerializeObject(volunteer);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest(message);
        }
    }
}
