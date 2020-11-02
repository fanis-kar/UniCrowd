using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.API.Data;
using Task.API.Repositories.Interfaces;

namespace Task.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tasks> GetTasks()
        {
            return _context
                .Tasks
                .ToList();
        }

        public Tasks GetTask(int taskId)
        {
            return _context.Tasks
                .Where(t => t.Id == taskId)
                .FirstOrDefault();
        }

        public void AddTask(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Tasks task)
        {
            var taskInDb = _context.Tasks.Single(t => t.Id == task.Id);

            taskInDb.Name = task.Name;
            taskInDb.Description = task.Description;
            taskInDb.VolunteerNumber = task.VolunteerNumber;
            taskInDb.ExpectedStartDate = task.ExpectedStartDate;
            taskInDb.ExpectedEndDate = task.ExpectedEndDate;
            taskInDb.StatusId = task.StatusId;

            _context.SaveChanges();
        }

        public IEnumerable<Skill> GetSkills()
        {
            return _context
                .Skills
                .ToList();
        }

        public Skill GetSkill(int skillId)
        {
            return _context.Skills
                .Where(s => s.Id == skillId)
                .FirstOrDefault();
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _context
                .Statuses
                .ToList();
        }

        public Status GetStatus(int statusId)
        {
            return _context.Statuses
                .Where(s => s.Id == statusId)
                .FirstOrDefault();
        }
    }
}
