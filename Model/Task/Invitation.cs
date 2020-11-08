using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Task.API

    public class Invitation
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool? Decision { get; set; }

        public DateTime Created { get; set; }

        public int TaskId { get; set; }

        public Tasks Task { get; set; }

        public int VolunteerId { get; set; }  // Volunteer.API - Volunteer[id]
    }
}
