﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace ApiCollection.Interfaces
{
    public interface ITaskApi
    {
        Task<List<Tasks>> GetTasks(string jwtToken);

        Task<List<Tasks>> GetTasksByUniversityId(int universityId, string jwtToken);

        Task<Tasks> GetTask(int taskId, string jwtToken);

        Task<string> AddTask(Tasks task, string jwtToken);

        Task<string> UpdateTask(Tasks task, string jwtToken);
    }
}
