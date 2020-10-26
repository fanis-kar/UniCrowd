using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace University.API.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            //--------------------------------------------------------------------//

            context.Database.EnsureCreated();

            if (context.Universities.Any())
            {
                return;   // DB has been seeded
            }

            //--------------------------------------------------------------------//

            if (!context.Universities.Any())
            {
                var universities = new List<Model.University>
                {
                    new Model.University
                    {
                        Abbreviation = "UniWa",
                        Name = "Πανεπιστήμιο Δυτικής Αττικής",
                        Address = "Αγίου Σπυρίδωνος 28, Αιγάλεω 122 43",
                        Website = "https://www.uniwa.gr",
                        Phone = "+302105385100",
                        AccountId = 1
                    },
                    new Model.University
                    {
                        Abbreviation = "UoA",
                        Name = "Εθνικό και Καποδιστριακό Πανεπιστήμιο Αθηνών",
                        Address = "Πανεπιστημίου 30, Αθήνα 106 79",
                        Website = "https://www.uoa.gr",
                        Phone = "+302107277000",
                        AccountId = 2
                    }
                };

                foreach (Model.University u in universities)
                {
                    context.Universities.Add(u);
                }
                context.SaveChanges();
            }

            //--------------------------------------------------------------------//

        }
    }
}
