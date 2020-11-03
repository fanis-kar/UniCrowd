using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.API.Data;
using Task.API.Repositories.Interfaces;

namespace Task.API.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
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
