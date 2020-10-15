﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.API.Data;

namespace University.API.Services
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly ApplicationDbContext _context;

        public UniversityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUniversity(Models.University university)
        {
            throw new NotImplementedException();
        }

        public void DeleteUniversity(int universityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.University> GetUniversities()
        {
            return _context.Universities.ToList();
        }

        public Models.University GetUniversity(int universityId)
        {
            return _context.Universities.Where(u => u.Id == universityId).FirstOrDefault();
        }

        public void UpdateUniversity(Models.University university)
        {
            throw new NotImplementedException();
        }
    }
}