using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class InvitationsListViewModel
    {
        public int InvitationId { get; set; }
        public int VolunteerId { get; set; }

        [Display(Name = "Ονοματεπώνυμο")]
        public string FullName { get; set; }

        [Display(Name = "Ικανότητες που έχει")]
        public int SkillsHave { get; set; }

        [Display(Name = "Ικανότητες που απαιτούνται")]
        public int SkillsRequired { get; set; }

        [Display(Name = "Ημερομηνία")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Απάντηση")]
        public bool Response { get; set; }
    }
}
