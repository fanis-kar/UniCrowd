using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    // Task.API

    public class Skill
    {
        public int Id { get; set; }

        [Display(Name = "Όνομασία")]
        public string Name { get; set; }

        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }

        //public List<VolunteerSkill> VolunteersSkills { get; set; }
    }
}
