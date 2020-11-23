using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerWebApplication.Models
{
    public class LoginFormViewModel
    {
        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Όνομα χρήστη")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Κωδικός πρόσβασης")]
        public string Password { get; set; }

        [Display(Name = "Να με θυμάσαι")]
        public bool? RememberMe { get; set; }
    }
}
