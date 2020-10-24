using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteer.API.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public List<int> Skills { get; set; } // Skill ids from Skill.API

        public int LeaderId { get; set; }
        
        public Volunteer Leader { get; set; }

        public List<Volunteer> Volunteers { get; set; }

        public DateTime Created { get; set; }
    }
}
