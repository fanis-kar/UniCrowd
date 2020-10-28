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

        public DateTime Created { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        public int UniversityId { get; set; }   // University.API - University[id]
    }
}
