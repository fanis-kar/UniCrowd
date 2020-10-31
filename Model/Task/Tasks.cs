using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Task.API

    public class Tasks
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int VolunteerNumber { get; set; }

        public DateTime Created { get; set; }

        public DateTime ExpectedStartDate { get; set; }

        public DateTime ExpectedEndDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        public int UniversityId { get; set; }   // University.API - University[id]
    }
}
