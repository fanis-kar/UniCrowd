using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Volunteer.API

    public class Volunteer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int Stars { get; set; }

        public int AccountId { get; set; } // Authentication.API - User[id]

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
