﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace UniversityWebApplication.ApiCollection.Interfaces
{
    public interface ISkillApi
    {
        Task<List<Skill>> GetSkills(string jwtToken);
        Task<Skill> GetSkill(int skillId, string jwtToken);
    }
}