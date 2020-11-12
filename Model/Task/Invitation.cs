using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    // Task.API

    public class Invitation
    {
        public int Id { get; set; }

        [Display(Name = "Τίτλος")]
        public string Title { get; set; }

        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }

        [Display(Name = "Απάντηση")]
        public bool? Decision { get; set; }

        [Display(Name = "Ημερομηνία δημιουργίας")]
        public DateTime Created { get; set; }

        [Display(Name = "Task")]
        public int TaskId { get; set; }

        [Display(Name = "Task")]
        public Tasks Task { get; set; }

        [Display(Name = "Εθελοντής")]
        public int VolunteerId { get; set; }  // Volunteer.API - Volunteer[id]
    }
}
