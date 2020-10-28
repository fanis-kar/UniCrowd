using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Invitation.API

    public class Invitation
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public int TaskId { get; set; }  // Task.API - Task[id]

        public int VolunteerId { get; set; }  // Volunteer.API - Volunteer[id]
    }
}
