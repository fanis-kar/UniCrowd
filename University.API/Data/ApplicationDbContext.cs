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
        public DbSet<University.API.Models.Faculty> Faculties { get; set; }
        public DbSet<University.API.Models.Department> Departments { get; set; }

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
                        Name = "Πανεπιστήμιο Δυτικής Αττικής",
                        Address = "Αγίου Σπυρίδωνος 28, Αιγάλεω 122 43",
                        Website = "https://www.uniwa.gr",
                        Phone = "+302105385100",
                        AccountId = 1
                    },
                    new University.API.Models.University
                    {
                        Id = 2,
                        Abbreviation = "UoA",
                        Name = "Εθνικό και Καποδιστριακό Πανεπιστήμιο Αθηνών",
                        Address = "Πανεπιστημίου 30, Αθήνα 106 79",
                        Website = "https://www.uoa.gr",
                        Phone = "+302107277000",
                        AccountId = 2
                    }
                );
        }
    }
}
