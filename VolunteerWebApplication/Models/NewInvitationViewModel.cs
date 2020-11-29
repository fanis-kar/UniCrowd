using System.ComponentModel.DataAnnotations;

namespace VolunteerWebApplication.Models
{
    public class NewInvitationViewModel
    {
        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Τίτλος")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }

        public int TaskId { get; set; }   // Task.API - Tasks[id]
    }
}
