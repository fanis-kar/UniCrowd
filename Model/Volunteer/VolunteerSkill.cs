using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Volunteer.API

    public class VolunteerSkill
    {
        public int VolunteerId { get; set; }

        public Volunteer Volunteer { get; set; }

        public int SkillId { get; set; }   // Skill.API - Skill[id]
    }
}
