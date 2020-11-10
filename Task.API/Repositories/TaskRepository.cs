using Microsoft.EntityFrameworkCore;
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
                .Include(t => t.Status)
                .Include(t => t.TasksSkills)
                    .ThenInclude(s => s.Skill)
                .Include(t => t.Invitations)
                .Include(t => t.Group)
                .ThenInclude(g => g.VolunteersGroups)
                .ToList();
        }

        public IEnumerable<Tasks> GetTasksByUniversityId(int universityId)
        {
            return _context
                .Tasks
                .Include(t => t.Status)
                .Include(t => t.TasksSkills)
                    .ThenInclude(s => s.Skill)
                .Include(t => t.Invitations)
                .Include(t => t.Group)
                .ThenInclude(g => g.VolunteersGroups)
                .Where(t => t.UniversityId == universityId)
                .ToList();
        }

        public Tasks GetTask(int taskId)
        {
            return _context
                .Tasks
                .Include(t => t.Status)
                .Include(t => t.TasksSkills)
                    .ThenInclude(s => s.Skill)
                .Include(t => t.Invitations)
                .Include(t => t.Group)
                .ThenInclude(g => g.VolunteersGroups)
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
    }
}
