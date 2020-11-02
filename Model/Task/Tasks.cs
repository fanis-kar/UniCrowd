using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    // Task.API

    public class Tasks
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Όνομασία")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Απαιτούμενος αριθμός εθελοντών")]
        public int VolunteerNumber { get; set; }

        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Αναμενόμενη ημερομηνία έναρξης")]
        public DateTime ExpectedStartDate { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Αναμενόμενη ημερομηνία λήξης")]
        public DateTime ExpectedEndDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Group Group { get; set; }

        [Display(Name = "Κατάσταση")]
        public int StatusId { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Απαιτούμενες ικανότητες")]
        public ICollection<TaskSkill> TasksSkills { get; set; }

        public int UniversityId { get; set; }   // University.API - University[id]
    }
}
