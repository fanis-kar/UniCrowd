using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volunteer.API.Data;
using Volunteer.API.Repositories.Interfaces;

namespace Volunteer.API.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly ApplicationDbContext _context;

        public VolunteerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Model.Volunteer> GetVolunteers()
        {
            return _context
                .Volunteers
                .ToList();
        }

        public Model.Volunteer GetVolunteer(int volunteerId)
        {
            return _context.Volunteers
                .Where(v => v.Id == volunteerId)
                .FirstOrDefault();
        }

        public Model.Volunteer GetVolunteerByUserId(int userId)
        {
            return _context.Volunteers
                .Where(v => v.AccountId == userId)
                .FirstOrDefault();
        }

        public void AddVolunteer(Model.Volunteer volunteer)
        {
            throw new NotImplementedException();
        }

        public void UpdateVolunteer(Model.Volunteer volunteer)
        {
            _context.Volunteers.Update(volunteer);
            _context.SaveChanges();
        }
    }
}
