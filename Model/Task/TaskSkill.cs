using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Task.API

    public class TaskSkill
    {
        public int TaskId { get; set; }

        public Tasks Task { get; set; }

        public int SkillId { get; set; }    // Skill.API - Skill[id]
    }
}
