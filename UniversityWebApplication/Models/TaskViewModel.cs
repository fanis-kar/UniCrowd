using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class TaskViewModel
    {
        public Tasks Task { get; set; }

        public List<Volunteer> Volunteers { get; set; }
    }
}
