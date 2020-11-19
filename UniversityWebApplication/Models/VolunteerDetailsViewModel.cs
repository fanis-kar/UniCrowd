using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class VolunteerDetailsViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Stars { get; set; }

        public IEnumerable<int> Skills { get; set; }
    }
}
