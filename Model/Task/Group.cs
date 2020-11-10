using Model.Task;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    // Task.API

    public class Group
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Όνομασία")]
        public string Name { get; set; }

        [Display(Name = "Αστέρια")]
        public int? Stars { get; set; }

        public int TaskId { get; set; }

        public Tasks Task { get; set; }

        public List<VolunteerGroup> VolunteersGroups { get; set; }
    }
}
