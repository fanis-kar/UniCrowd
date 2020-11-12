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
            var taskInDb = _context
                .Tasks
                .Where(t => t.Id == task.Id)
                .FirstOrDefault();

            //--------------------------------------------//

            var skillsToDelete = _context
                .TasksSkills
                .Where(s => s.TaskId == task.Id)
                .ToList();

            _context.RemoveRange(skillsToDelete);
            _context.SaveChanges();

            //--------------------------------------------//

            taskInDb.Name = task.Name;
            taskInDb.Description = task.Description;
            taskInDb.VolunteerNumber = task.VolunteerNumber;
            taskInDb.ExpectedStartDate = task.ExpectedStartDate;
            taskInDb.ExpectedEndDate = task.ExpectedEndDate;
            taskInDb.StartDate = task.StartDate;
            taskInDb.EndDate = task.EndDate;
            taskInDb.StatusId = task.StatusId;
            taskInDb.TasksSkills = task.TasksSkills;

            _context.SaveChanges();
        }
    }
}
