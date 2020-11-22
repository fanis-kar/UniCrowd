using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class NewUniversityReportViewModel
    {
        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Τίτλος")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Περιόμενο")]
        public string Content { get; set; }

        public int TaskId { get; set; }   // Task.API - Tasks[id]
    }
}
