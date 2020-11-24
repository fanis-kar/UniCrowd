using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace ApiCollection.Interfaces
{
    public interface IStatusApi
    {
        Task<List<Status>> GetStatuses(string jwtToken);
        Task<Status> GetStatus(int statusId, string jwtToken);
    }
}
