using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace Volunteer.API.Repositories.Interfaces
{
    public interface IVolunteerRepository
    {
        IEnumerable<Model.Volunteer> GetVolunteers();

        Model.Volunteer GetVolunteer(int volunteerId);

        Model.Volunteer GetVolunteerByUserId(int volunteerId);

        void AddVolunteer(Model.Volunteer volunteer);

        void UpdateVolunteer(Model.Volunteer volunteer);
    }
}
