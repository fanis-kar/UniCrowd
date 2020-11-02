using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace UniversityWebApplication.ApiCollection.Interfaces
{
    public interface ITaskApi
    {
        Task<List<Tasks>> GetTasks(string jwtToken);
        Task<Tasks> GetTask(int taskId, string jwtToken);
        Task<string> AddTask(Tasks task, string jwtToken);
    }
}
