using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder
                .Entity<Status>()
                .HasData(
                    new Status
                    {
                        Id = 1,
                        Name = "1. ΔΗΜΙΟΥΡΓΙΑ GROUP"
                    },
                    new Status
                    {
                        Id = 2,
                        Name = "2. ΕΝΕΡΓΟ TASK"
                    },
                    new Status
                    {
                        Id = 3,
                        Name = "3. ΟΛΟΚΛΗΡΩΜΕΝΟ TASK"
                    },
                    new Status
                    {
                        Id = 4,
                        Name = "4. ΑΚΥΡΩΜΕΝΟ TASK"
                    }
                );

            //-------------------------------------------------------//

            builder
                .Entity<Skill>()
                .HasData(
                    new Skill
                    {
                        Id = 1,
                        Name = "Βασικές γνώσεις Η/Υ",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 2,
                        Name = "Προγραμματισμός με JAVA",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 3,
                        Name = "Προγραμματισμός με C#",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 4,
                        Name = "Προγραμματισμός με Python",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 5,
                        Name = "Ανάπτυξη Web εφαρμογών με JAVA",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 6,
                        Name = "Ανάπτυξη Web εφαρμογών με C#",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 7,
                        Name = "Ανάπτυξη mobile εφαρμογών με JAVA",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 8,
                        Name = "Ανάπτυξη mobile εφαρμογών με Xamarin Forms",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 9,
                        Name = "Μηχανική μάθηση",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 10,
                        Name = "Εξόρυξη δεδομένων",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 11,
                        Name = "Διαχείριση δεδομένων μεγάλης κλίμακας",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 12,
                        Name = "SQL Server",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 13,
                        Name = "MongoDB",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 14,
                        Name = "MySQL",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 15,
                        Name = "Αγγλικά - Καλή γνώση (B2)",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 16,
                        Name = "Αγγλικά - Πολύ καλή γνώση (Γ1)",
                        Description = "Μη διαθέσιμη"
                    },
                    new Skill
                    {
                        Id = 17,
                        Name = "Αγγλικά - Άριστη γνώση (Γ2)",
                        Description = "Μη διαθέσιμη"
                    }
                );

            //-------------------------------------------------------//

            builder
                .Entity<VolunteerSkill>()
                .HasData(
                    new VolunteerSkill
                    {
                        VolunteerId = 1,
                        SkillId = 3
                    },
                    new VolunteerSkill
                    {
                        VolunteerId = 1,
                        SkillId = 6
                    },
                    new VolunteerSkill
                    {
                        VolunteerId = 1,
                        SkillId = 8
                    },
                    new VolunteerSkill
                    {
                        VolunteerId = 1,
                        SkillId = 12
                    },
                    new VolunteerSkill
                    {
                        VolunteerId = 1,
                        SkillId = 15
                    }
                );

            //-------------------------------------------------------//
        }
    }
}
