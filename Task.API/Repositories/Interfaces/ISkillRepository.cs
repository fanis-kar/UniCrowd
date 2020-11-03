using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetSkills();

        Skill GetSkill(int skillId);
    }
}
