using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Group.API

    public class VolunteerReport
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
