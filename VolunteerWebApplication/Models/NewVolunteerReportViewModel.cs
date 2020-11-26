using System.ComponentModel.DataAnnotations;

namespace VolunteerWebApplication.Models
{
    public class NewVolunteerReportViewModel
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
