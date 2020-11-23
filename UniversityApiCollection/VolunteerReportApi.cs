using UniversityApiCollection.Infrastructure;
using UniversityApiCollection.Interfaces;
using Model;
using Model.Report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApiCollection
{
    public class VolunteerReportApi : BaseHttpClientWithFactory, IVolunteerReportApi
    {
        public VolunteerReportApi(IHttpClientFactory factory)
            : base(factory)
        {
        }

        public async Task<List<VolunteerReport>> GetVolunteersReports(string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/VolunteerReport")
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<List<VolunteerReport>>(message);
        }

        public async Task<VolunteerReport> GetVolunteerReport(string reportId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/VolunteerReport")
                           .AddToPath(reportId)
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<VolunteerReport>(message);
        }

        public async Task<string> AddVolunteerReport(VolunteerReport VolunteerReport, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/VolunteerReport")
                           .HttpMethod(HttpMethod.Post)
                           .Headers(authorization)
                           .GetHttpMessage();

            var json = JsonConvert.SerializeObject(VolunteerReport);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest(message);
        }
    }
}
