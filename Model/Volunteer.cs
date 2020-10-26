using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Volunteer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public List<Skill> Skills { get; set; }

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
