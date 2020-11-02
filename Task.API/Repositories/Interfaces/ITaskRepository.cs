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

        Tasks GetTask(int taskId);

        void AddTask(Tasks task);

        void UpdateTask(Tasks task);

        IEnumerable<Skill> GetSkills();

        Skill GetSkill(int skillId);

        IEnumerable<Status> GetStatuses();

        Status GetStatus(int statusId);
    }
}
