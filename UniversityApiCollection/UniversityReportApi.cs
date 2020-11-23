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
    public class UniversityReportApi : BaseHttpClientWithFactory, IUniversityReportApi
    {
        public UniversityReportApi(IHttpClientFactory factory)
            : base(factory)
        {
        }

        public async Task<List<UniversityReport>> GetUniversitiesReports(string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/UniversityReport")
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<List<UniversityReport>>(message);
        }

        public async Task<UniversityReport> GetUniversityReport(string reportId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/UniversityReport")
                           .AddToPath(reportId)
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<UniversityReport>(message);
        }

        public async Task<string> AddUniversityReport(UniversityReport universityReport, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection
            {
                { "Authorization", "Bearer " + jwtToken }
            };

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/UniversityReport")
                           .HttpMethod(HttpMethod.Post)
                           .Headers(authorization)
                           .GetHttpMessage();

            var json = JsonConvert.SerializeObject(universityReport);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest(message);
        }
    }
}
