using Model;
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
    public class SkillApi : BaseHttpClientWithFactory, ISkillApi
    {
        public SkillApi(IHttpClientFactory factory)
            : base(factory)
        {
        }

        public async Task<List<Skill>> GetSkills(string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection();
            authorization.Add("Authorization", "Bearer " + jwtToken);

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Skill")
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<List<Skill>>(message);
        }

        public async Task<Skill> GetSkill(int skillId, string jwtToken)
        {
            NameValueCollection authorization = new NameValueCollection();
            authorization.Add("Authorization", "Bearer " + jwtToken);

            var message = new HttpRequestBuilder("https://localhost:44378")
                           .SetPath("/Skill")
                           .AddToPath(skillId.ToString())
                           .HttpMethod(HttpMethod.Get)
                           .Headers(authorization)
                           .GetHttpMessage();

            return await SendRequest<Skill>(message);
        }
    }
}
