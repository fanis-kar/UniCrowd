using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    // University.API

    public class Department
    {
        public int Id { get; set; }

        [Display(Name = "Συντομογραφία")]
        public string Abbreviation { get; set; }

        [Display(Name = "Όνομασία")]
        public string Name { get; set; }

        [Display(Name = "Ιστοσελίδα")]
        public string Website { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Τηλέφωνο")]
        public string Phone { get; set; }

        [Display(Name = "Σχολή")]
        public int FacultyId { get; set; }

        [Display(Name = "Σχολή")]
        public Faculty Faculty { get; set; }

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
