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

        public DbSet<Models.University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Models.University>()
                .HasData(
                    new Models.University
                    {
                        Id = 1,
                        Abbreviation = "uniwa",
                        Name = "Πανεπιστήμιο Δυτικής Αττικής",
                        Address = "Αγίου Σπυρίδωνος 28, Αιγάλεω 122 43",
                        Website = "https://www.uniwa.gr",
                        Phone = "+302105385100",
                        AccountId = 1
                    },
                    new Models.University
                    {
                        Id = 2,
                        Abbreviation = "uoa",
                        Name = "Εθνικό και Καποδιστριακό Πανεπιστήμιο Αθηνών",
                        Address = "Πανεπιστημίου 30, Αθήνα 106 79",
                        Website = "https://www.uoa.gr",
                        Phone = "+302107277000",
                        AccountId = 2
                    }
                );

            builder
                .Entity<Faculty>()
                .HasData(
                    new Faculty
                    {
                        Id = 1,
                        Abbreviation = "sph",
                        Name = "Σχολή Δημόσιας Υγείας",
                        Website = "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/sph/",
                        Email = "sph@uniwa.gr",
                        Phone = "+302132010115",
                        UniversityId = 1
                    },
                    new Faculty
                    {
                        Id = 2,
                        Abbreviation = "sdo",
                        Name = "Σχολή Διοικητικών, Οικονομικών & Κοινωνικών Επιστημών",
                        Website = "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/sdo/",
                        Email = "sdoke@uniwa.gr",
                        Phone = "",
                        UniversityId = 1
                    },
                    new Faculty
                    {
                        Id = 3,
                        Abbreviation = "ffs",
                        Name = "Σχολή Επιστημών Τροφίμων",
                        Website = "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/ffs/",
                        Email = "ffs@uniwa.gr",
                        Phone = "2105385501",
                        UniversityId = 1
                    },
                    new Faculty
                    {
                        Id = 4,
                        Abbreviation = "seyp",
                        Name = "Σχολή Επιστημών Υγείας και Πρόνοιας",
                        Website = "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/seyp/",
                        Email = "seyp@uniwa.gr",
                        Phone = "2105385601",
                        UniversityId = 1
                    },
                    new Faculty
                    {
                        Id = 5,
                        Abbreviation = "aac",
                        Name = "Σχολή Εφαρμοσμένων Τεχνών και Πολιτισμού",
                        Website = "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/aac/",
                        Email = "setp@uniwa.gr",
                        Phone = "2105385401",
                        UniversityId = 1
                    },
                    new Faculty
                    {
                        Id = 6,
                        Abbreviation = "feng",
                        Name = "Σχολή Μηχανικών",
                        Website = "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/feng/",
                        Email = "feng@uniwa.gr",
                        Phone = "+302105381212",
                        UniversityId = 1
                    }
                );
        }
    }
}
