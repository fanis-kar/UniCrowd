using Model;
using System.Collections.Generic;

namespace VolunteerWebApplication.Models
{
    public class GroupDetailsViewModel
    {
        public Group Group { get; set; }

        public University University { get; set; }

        public List<Volunteer> Volunteers { get; set; }
    }
}
