using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Models
{
    public class Invitation
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Deadline { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}
