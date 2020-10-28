using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // University.API

    public class University
    {
        public int Id { get; set; }

        public string Abbreviation { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }

        public string Phone { get; set; }

        public List<Faculty> Faculties { get; set; }

        public int AccountId { get; set; }  // Authentication.API - User[id]

        public string OfficialName
        {
            get
            {
                return Name + " (" + Abbreviation + ")";
            }
        }
    }
}
