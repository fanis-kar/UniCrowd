using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace VolunteerApiCollection.Interfaces
{
    public interface IInvitationApi
    {
        Task<List<Invitation>> GetInvitations(string jwtToken);

        Task<List<Invitation>> GetInvitationsByTaskId(int taskId, string jwtToken);

        Task<Invitation> GetInvitation(int invitationId, string jwtToken);

        Task<string> AddInvitation(Invitation invitation, string jwtToken);

        Task<string> UpdateInvitation(Invitation invitation, string jwtToken);
    }
}
