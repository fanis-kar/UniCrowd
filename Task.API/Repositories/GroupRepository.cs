using MassTransit;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Queue;
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
        private readonly IBus _bus;

        public GroupRepository(ApplicationDbContext context, IBus bus)
        {
            _context = context;
            _bus = bus;
        }

        public IEnumerable<Group> GetGroups()
        {
            return _context
                .Groups
                .Include(g => g.Task)
                .ThenInclude(t => t.Invitations)
                .Include(g => g.VolunteersGroups)
                .ToList();
        }

        public Group GetGroup(int groupId)
        {
            return _context
                .Groups
                .Include(g => g.Task)
                .ThenInclude(t => t.Invitations)
                .Include(g => g.VolunteersGroups)
                .Where(g => g.Id == groupId)
                .FirstOrDefault();
        }

        public void AddGroup(Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public async System.Threading.Tasks.Task UpdateGroupAsync(Group group)
        {
            var groupInDb = _context
                .Groups
                .Where(g => g.Id == group.Id)
                .FirstOrDefault();

            //--------------------------------------------//

            var volunteersToDelete = _context
                .VolunteersGroups
                .Where(vg => vg.GroupId == group.Id)
                .ToList();

            _context.RemoveRange(volunteersToDelete);
            _context.SaveChanges();

            //--------------------------------------------//

            groupInDb.Name = group.Name;
            groupInDb.Stars = group.Stars;
            groupInDb.VolunteersGroups = group.VolunteersGroups;

            //--------------------------------------------//

            var oldStars = groupInDb.Stars;
            var newStars = group.Stars;

            _context.SaveChanges();

            //--------------------------------------------//

            foreach(var volunteer in groupInDb.VolunteersGroups)
            {
                List<Group> volunteerGroups = _context.VolunteersGroups.Where(vg => vg.VolunteerId == volunteer.VolunteerId).Select(g => g.Group).ToList();

                var sum = 0;
                var count = 0;
                var stars = 0;

                foreach(var groupTemp in volunteerGroups)
                {
                    sum = (int)(sum + groupTemp.Stars);
                    count++;
                }

                if (count > 0)
                    stars = sum / count;


                _ = System.Threading.Tasks.Task.Run(async () => await SendVolunteerStarsAsync(volunteer.VolunteerId, stars));
            }
   
        }

        private async System.Threading.Tasks.Task SendVolunteerStarsAsync(int volunteerId, float stars)
        {
            UpdateVolunteerStars updateVolunteerStars = new UpdateVolunteerStars()
            {
                VolunteerId = volunteerId,
                Stars = stars
            };

            Uri uri = new Uri("rabbitmq://localhost/updateVolunteerStarsQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(updateVolunteerStars);
        }
    }
}
