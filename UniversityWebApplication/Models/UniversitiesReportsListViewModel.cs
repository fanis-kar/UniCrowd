using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityWebApplication.Models
{
    public class UniversitiesReportsListViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Τίτλος")]
        public string Title { get; set; }

        [Display(Name = "Ημερομηνία")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Created { get; set; }

        public int TaskId { get; set; }

        [Display(Name = "Task")]
        public string TaskName { get; set; }
    }
}
