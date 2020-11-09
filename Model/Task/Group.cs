using Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Task.API

    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Stars { get; set; }

        public int TaskId { get; set; }

        public Tasks Task { get; set; }

        public List<VolunteerGroup> VolunteersGroups { get; set; }
    }
}
