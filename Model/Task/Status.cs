using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    // Task.API

    public class Status
    {
        public int Id { get; set; }

        [Display(Name = "Κατάσταση")]
        public string Name { get; set; }
    }
}
