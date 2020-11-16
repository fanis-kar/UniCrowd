using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class ManageGroupViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Το πεδίο απαιτείται!")]
        [Display(Name = "Όνομασία")]
        public string Name { get; set; }

        [Display(Name = "Αστέρια")]
        [Range(0, 5)]
        public int Stars { get; set; }

        [Display(Name = "Προσκλήσεις")]
        public List<InvitationsListViewModel> Invitations { get; set; }
    }
}
