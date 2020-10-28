using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // University.API

    public class Faculty
    {
        public int Id { get; set; }

        public string Abbreviation { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int UniversityId { get; set; }

        public University University { get; set; }

        public List<Department> Departments { get; set; }

        public string OfficialName
        {
            get
            {
                return Name + " (" + Abbreviation + ")";
            }
        }
    }
}
