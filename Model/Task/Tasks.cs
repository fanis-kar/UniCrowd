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

        [Display(Name = "Όνομασία")]
        public string Name { get; set; }

        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }

        [Display(Name = "Απαιτούμενος αριθμός εθελοντών")]
        public int VolunteerNumber { get; set; }

        [Display(Name = "Ημερομηνία δημιουργίας")]
        public DateTime Created { get; set; }

        [Display(Name = "Αναμενόμενη ημερομηνία έναρξης")]
        public DateTime ExpectedStartDate { get; set; }

        [Display(Name = "Αναμενόμενη ημερομηνία λήξης")]
        public DateTime ExpectedEndDate { get; set; }

        [Display(Name = "Ημερομηνία έναρξης")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Ημερομηνία λήξης")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Group")]
        public Group Group { get; set; } // One-to-One relationship

        [Display(Name = "Κατάσταση")]
        public int StatusId { get; set; }

        [Display(Name = "Κατάσταση")]
        public Status Status { get; set; }

        [Display(Name = "Απαιτούμενες ικανότητες")]
        public ICollection<TaskSkill> TasksSkills { get; set; }

        [Display(Name = "Προσκλήσεις")]
        public ICollection<Invitation> Invitations { get; set; }

        [Display(Name = "Πανεπιστήμιο")]
        public int UniversityId { get; set; }   // University.API - University[id]
    }
}
