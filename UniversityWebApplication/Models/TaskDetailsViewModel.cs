using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
