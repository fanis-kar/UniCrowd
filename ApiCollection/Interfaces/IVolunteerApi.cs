using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace ApiCollection.Interfaces
{
    public interface IVolunteerApi
    {
        Task<List<Volunteer>> GetVolunteers(string jwtToken);
        Task<Volunteer> GetVolunteer(int volunteerId, string jwtToken);
    }
}
