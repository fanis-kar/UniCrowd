using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    // University.API

    public class University
    {
        public int Id { get; set; }

        [Display(Name = "Συντομογραφία")]
        public string Abbreviation { get; set; }

        [Display(Name = "Όνομασία")]
        public string Name { get; set; }

        [Display(Name = "Διεύθυνση")]
        public string Address { get; set; }

        [Display(Name = "Ιστοσελίδα")]
        public string Website { get; set; }

        [Display(Name = "Τηλέφωνο")]
        public string Phone { get; set; }

        [Display(Name = "Σχολές")]
        public List<Faculty> Faculties { get; set; }

        [Display(Name = "Λογαριασμός")]
        public int AccountId { get; set; }  // Authentication.API - User[id]

        [Display(Name = "Επίσημη ονομασία")]
        public string OfficialName
        {
            get
            {
                return Name + " (" + Abbreviation + ")";
            }
        }
    }
}
