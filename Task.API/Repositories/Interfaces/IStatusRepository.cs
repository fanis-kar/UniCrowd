using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetStatuses();

        Status GetStatus(int statusId);
    }
}
