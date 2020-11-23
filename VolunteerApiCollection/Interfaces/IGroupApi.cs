using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace VolunteerApiCollection.Interfaces
{
    public interface IGroupApi
    {
        Task<List<Group>> GetGroups(string jwtToken);

        Task<List<Group>> GetVolunteerGroups(int volunteerId, string jwtToken);

        Task<Group> GetGroup(int groupId, string jwtToken);

        Task<string> AddGroup(Group group, string jwtToken);

        Task<string> UpdateGroup(Group group, string jwtToken);
    }
}
