using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Task.API

    public class VolunteerSkill
    {
        public int VolunteerId { get; set; }  // Volunteer.API - Volunteer[id]

        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}
