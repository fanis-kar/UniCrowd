using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    // Authentication.API

    public class Role
    {
        public int Id { get; set; }

        [Display(Name = "Όνομασία")]
        public string Name { get; set; }
    }
}
