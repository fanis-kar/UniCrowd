using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using ApiCollection.Infrastructure;
using ApiCollection.Interfaces;

namespace ApiCollection
{
    public class AuthenticationApi : BaseHttpClientWithFactory, IAuthenticationApi
    {
        public AuthenticationApi(IHttpClientFactory factory)
            : base(factory)
        {
        }

        public async Task<string> Login(User user)
        {
            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Authentication/Login")
                           .AddQueryString("destination", "university-area")
                           .HttpMethod(HttpMethod.Post)
                           .GetHttpMessage();

            var json = JsonConvert.SerializeObject(user);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest(message);
        }

        public async Task<User> GetUser(int userId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Authentication")
                           .AddToPath(userId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<User>(message);
        }

        public async Task<string> ValidateUserAsync(int userId, string jwtToken)
        {
            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Authentication/Validate/" + userId.ToString() + "/" + jwtToken.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .GetHttpMessage();

            return await SendRequest<string>(message);
        }
    }
}