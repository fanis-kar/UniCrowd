using University.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<University.API.Models.University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<University.API.Models.University>()
                .HasData(
                    new University.API.Models.University
                    {
                        Id = 1,
                        Abbreviation = "UniWa",
                        Name = "University of West Attica",
                        Address = "Agioy Spyridonos",
                        Website = "https://www.uniwa.gr",
                        Phone = "2102221656",
                        AccountId = 5
                    }
                );
        }
    }
}
