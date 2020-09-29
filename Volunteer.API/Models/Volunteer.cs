using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteer.API.Models
{
    public class Volunteer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public List<int> Skills { get; set; } // Skill ids from Skill.API

        public int AccountId { get; set; } // Authentication.API.User[id]

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
