using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class GroupDetailsViewModel
    {
        public Group Group { get; set; }

        public University University { get; set; }

        public List<Volunteer> Volunteers { get; set; }
    }
}
