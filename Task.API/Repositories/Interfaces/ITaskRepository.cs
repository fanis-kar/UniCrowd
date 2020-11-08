using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Tasks> GetTasks();

        IEnumerable<Tasks> GetTasksByUniversityId(int taskId);

        Tasks GetTask(int taskId);

        void AddTask(Tasks task);

        void UpdateTask(Tasks task);
    }
}
