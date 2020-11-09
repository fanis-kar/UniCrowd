﻿using Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UniversityWebApplication.ApiCollection.Infrastructure;
using UniversityWebApplication.ApiCollection.Interfaces;

namespace UniversityWebApplication.ApiCollection
{
    public class StatusApi : BaseHttpClientWithFactory, IStatusApi
    {
        public StatusApi(IHttpClientFactory factory)
            : base(factory)
        {
        }

        public async Task<List<Status>> GetStatuses(string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection();
            authorization.Add("Authorization", "Bearer " + jwtToken);

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Status")
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<List<Status>>(message);
        }

        public async Task<Status> GetStatus(int statusId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection();
            authorization.Add("Authorization", "Bearer " + jwtToken);

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Status")
                           .AddToPath(statusId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<Status>(message);
        }
    }
}