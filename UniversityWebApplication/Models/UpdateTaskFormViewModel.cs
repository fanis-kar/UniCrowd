using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class UpdateTaskFormViewModel
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

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Αναμενόμενη ημερομηνία έναρξης")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpectedStartDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Αναμενόμενη ημερομηνία λήξης")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpectedEndDate { get; set; } = DateTime.Now;

        [Display(Name = "Κατάσταση")]
        public int StatusId { get; set; }

        public IEnumerable<Status> Statuses { get; set; }

        [Display(Name = "Απαιτούμενες ικανότητες")]
        public IEnumerable<int> Skills { get; set; }
    }
}
