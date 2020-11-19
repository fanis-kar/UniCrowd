using MassTransit;
using Model.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volunteer.API.Data;

namespace Volunteer.API.Consumers
{
    public class UpdateVolunteerConsumer : IConsumer<UpdateVolunteerStars>
    {
        private readonly ApplicationDbContext _context;

        public UpdateVolunteerConsumer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<UpdateVolunteerStars> context)
        {
            var data = context.Message;
            System.Diagnostics.Debug.WriteLine(data.VolunteerId + " " + data.Stars);
            Model.Volunteer volunteerInDb = _context.Volunteers.Where(v => v.Id == data.VolunteerId).FirstOrDefault();

            if(volunteerInDb != null)
            {
                volunteerInDb.Stars = data.Stars;

                _context.Volunteers.Update(volunteerInDb);
                _context.SaveChanges();
            }
        }
    }
}
