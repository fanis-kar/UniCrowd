using Skill.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.API.Models;

namespace Task.API.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public DateTime Created { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime Deadline { get; set; }

        public List<Skill.API.Models.Skill> SkillsRequeired { get; set; }

        public List<Invitation> Invitations { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        Initial,
        GatheringInvitations,
        Pending,
        Canceled,
        Completed
    }
}
