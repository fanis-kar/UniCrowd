using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class University
    {
        public int Id { get; set; }

        public string Abbreviation { get; set; }

        public string Name { get; set; }

        [Display(Name = "Διεύθυνση")]
        public string Address { get; set; }

        [Display(Name = "Ιστοσελίδα")]
        public string Website { get; set; }

        [Display(Name = "Τηλέφωνο")]
        public string Phone { get; set; }

        public int AccountId { get; set; } // Authentication.API.User[id]

        [Display(Name = "Επίσημη Ονομασία")]
        public string OfficialName
        {
            get
            {
                return Name + " (" + Abbreviation + ")";
            }
        }
    }
}
