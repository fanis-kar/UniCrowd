﻿using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.API.Data;
using Task.API.Repositories.Interfaces;

namespace Task.API.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Skill> GetSkills()
        {
            return _context
                .Skills
                .ToList();
        }

        public Skill GetSkill(int skillId)
        {
            return _context.Skills
                .Where(s => s.Id == skillId)
                .FirstOrDefault();
        }

        public IEnumerable<Skill> GetVolunteerSkills(int volunteerId)
        {
            return _context
                .VolunteersSkills
                .Where(vs => vs.VolunteerId == volunteerId)
                .Select(s => s.Skill)
                .ToList();
        }
    }
}
