using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Task.API

    public class Skill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<TaskSkill> TasksSkills { get; set; }
    }
}
