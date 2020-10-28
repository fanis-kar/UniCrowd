using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Group.API

    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stars { get; set; }

        public int TaskId { get; set; }  // Task.API - Task[id]

        public int VolunteerId { get; set; }  // Volunteer.API - Volunteer[id]
    }
}
