using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerWebApplication.Models
{
    public class VolunteerDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Όνομα")]
        public string FirstName { get; set; }

        [Display(Name = "Επώνυμο")]
        public string LastName { get; set; }

        [Display(Name = "Πατρώνυμο")]
        public string FatherName { get; set; }

        [Display(Name = "Τηλέφωνο")]
        public string Phone { get; set; }

        [Display(Name = "Διεύθυνση")]
        public string Address { get; set; }

        [Display(Name = "Αστέρια")]
        public string Stars { get; set; }

        [Display(Name = "Δεξιότητες")]
        public IEnumerable<int> Skills { get; set; }

        [Display(Name = "Groups")]
        public IEnumerable<Group> Groups { get; set; }
    }
}
