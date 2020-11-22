using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class UniversityReportDetailsViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Τίτλος")]
        public string Title { get; set; }

        [Display(Name = "Περιόμενο")]
        public string Content { get; set; }

        [Display(Name = "Ημερομηνία")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Created { get; set; }

        public int TaskId { get; set; }   // Task.API - Tasks[id]

        [Display(Name = "Task")]
        public string TaskName { get; set; }
    }
}
