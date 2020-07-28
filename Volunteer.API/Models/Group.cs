using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteer.API.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Volunteer> Volunteers { get; set; }

        public DateTime Created { get; set; }
    }
}
