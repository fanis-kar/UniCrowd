﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Repositories.Interfaces
{
    public interface IInvitationRepository
    {
        IEnumerable<Invitation> GetInvitations();

        IEnumerable<Invitation> GetInvitationsByTaskId(int taskId);

        Invitation GetInvitation(int invitationId);

        void AddInvitation(Invitation invitation);

        void UpdateInvitation(Invitation invitation);
    }
}
