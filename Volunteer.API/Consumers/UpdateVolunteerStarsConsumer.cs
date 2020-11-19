using MassTransit;
using Model.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volunteer.API.Data;

namespace Volunteer.API.Consumers
{
    public class UpdateVolunteerStarsConsumer : IConsumer<UpdateVolunteerStars>
    {
        private readonly ApplicationDbContext _context;

        public UpdateVolunteerStarsConsumer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<UpdateVolunteerStars> context)
        {
            var data = context.Message;
            Model.Volunteer volunteerInDb = _context.Volunteers.Where(v => v.Id == data.VolunteerId).FirstOrDefault();

            System.Diagnostics.Debug.WriteLine("======UpdateVolunteerStarsConsumer======");
            System.Diagnostics.Debug.WriteLine("VolunteerId: " + data.VolunteerId + " Stars: " + data.Stars);

            if (volunteerInDb != null)
            {
                volunteerInDb.Stars = data.Stars;

                _context.Volunteers.Update(volunteerInDb);
                _context.SaveChanges();
            }
        }
    }
}
