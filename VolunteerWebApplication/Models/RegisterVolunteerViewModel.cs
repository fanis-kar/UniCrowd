using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerWebApplication.Models
{
    public class RegisterVolunteerViewModel
    {
        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Όνομα χρήστη")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [EmailAddress(ErrorMessage = "Μη έγκυρο email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Κωδικός πρόσβασης")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Compare("Password")]
        [Display(Name = "Επιβεβαίωση Κωδικού πρόσβασης")]
        public string ConfirmPassword { get; set; }

        //------------------------------------------------//

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Όνομα")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Επώνυμο")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Πατρώνυμο")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Τηλέφωνο")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Διεύθυνση")]
        public string Address { get; set; }
    }
}