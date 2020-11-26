using Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityWebApplication.Models
{
    public class TaskDetailsViewModel
    {
        public Tasks Task { get; set; }

        [Display(Name = "Απαιτούμενες ικανότητες")]
        public string Skills { get; set; }

        public List<Volunteer> Volunteers { get; set; }
    }
}
