using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Task
{
    // Task.API

    public class VolunteerGroup
    {
        public int VolunteerId { get; set; }  // Volunteer.API - Volunteer[id]

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
