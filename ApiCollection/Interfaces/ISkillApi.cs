using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace ApiCollection.Interfaces
{
    public interface ISkillApi
    {
        Task<List<Skill>> GetSkills(string jwtToken);

        Task<Skill> GetSkill(int skillId, string jwtToken);

        Task<List<Skill>> GetVolunteerSkills(int volunteerId, string jwtToken);
    }
}
