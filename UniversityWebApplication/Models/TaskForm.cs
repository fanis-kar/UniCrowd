using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityWebApplication.Models
{
    public class TaskForm
    {
        public Tasks Task { get; set; }

        public IEnumerable<Skill> Skills { get; set; }

        public IEnumerable<Status> Statuses { get; set; }

        public string Title
        {
            get
            {
                if (Task != null && Task.Id != 0)
                    return "Ενημέρωση Task";

                return "Νέο Task";
            }
        }
    }
}
