using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class TaskFormViewModel
    {
        public int? Id { get; set; }

        //-------------------------------------------------//

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
        public DateTime ExpectedStartDate { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Αναμενόμενη ημερομηνία λήξης")]
        public DateTime ExpectedEndDate { get; set; }

        [Display(Name = "Κατάσταση")]
        public int StatusId { get; set; }

        [Display(Name = "Απαιτούμενες ικανότητες")]
        public IEnumerable<int> Skills { get; set; }

        //-------------------------------------------------//

        public IEnumerable<Status> Statuses { get; set; }

        //-------------------------------------------------//

        public string Title
        {
            get
            {
                return Id != 0 ? "Ενημέρωση Task" : "Νέο Task";
            }
        }

        //-------------------------------------------------//

        public TaskFormViewModel()
        {
            Id = 0;
        }

        public TaskFormViewModel(Tasks task)
        {
            Id = task.Id;
        }
    }
}
