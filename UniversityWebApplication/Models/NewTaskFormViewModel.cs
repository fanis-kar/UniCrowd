using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class NewTaskFormViewModel
    {
        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Όνομασία")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Range(1, 100, ErrorMessage = "Παρακαλώ εισάγετε μια τιμή μεταξύ {1} και {2}.")]
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

        [Display(Name = "Απαιτούμενες ικανότητες")]
        public IEnumerable<int> Skills { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Όνομασία Group")]
        public string GroupName { get; set; }
    }
}
