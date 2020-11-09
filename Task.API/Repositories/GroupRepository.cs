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
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Group> GetGroups()
        {
            return _context
                .Groups
                .Include(g => g.VolunteersGroups)
                .ToList();
        }

        public Group GetGroup(int groupId)
        {
            return _context
                .Groups
                .Include(g => g.VolunteersGroups)
                .Where(g => g.Id == groupId)
                .FirstOrDefault();
        }

        public void AddGroup(Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public void UpdateGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
