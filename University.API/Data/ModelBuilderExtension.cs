using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.API.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder
                .Entity<Model.University>()
                .HasData(
                    new Model.University
                    {
                        Id = 1,
                        Abbreviation = "uniwa",
                        Name = "Πανεπιστήμιο Δυτικής Αττικής",
                        Address = "Αγίου Σπυρίδωνος 28, Αιγάλεω 122 43",
                        Website = "https://www.uniwa.gr",
                        Phone = "+302105385100",
                        AccountId = 1
                    },
                    new Model.University
                    {
                        Id = 2,
                        Abbreviation = "aueb",
                        Name = "Οικονομικό Πανεπιστήμιο Αθηνών",
                        Address = "Πατησίων 76, Αθήνα 104 34",
                        Website = "https://www.aueb.gr",
                        Phone = "+302108203911",
                        AccountId = 2
                    }
                );

            //--------------------------------------------------------------------------------//

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
                    },
                    new Faculty
                    {
                        Id = 7,
                        Abbreviation = "sde",
                        Name = "Σχολή Διοίκησης Επιχειρήσεων",
                        Website = "https://www.dept.aueb.gr/el/school_of_business",
                        Email = "sde@aueb.gr",
                        Phone = "+302108214510",
                        UniversityId = 2
                    },
                    new Faculty
                    {
                        Id = 8,
                        Abbreviation = "soe",
                        Name = "Σχολή Οικονομικών Επιστημών",
                        Website = "https://www.dept.aueb.gr/el/school_of_economics",
                        Email = "secr_soe@aueb.gr",
                        Phone = "+302108203416",
                        UniversityId = 2
                    },
                    new Faculty
                    {
                        Id = 9,
                        Abbreviation = "soi",
                        Name = "Σχολή Επιστημών και Τεχνολογίας της Πληροφορίας",
                        Website = "https://www.dept.aueb.gr/el/school_of_informatics",
                        Email = "webmaster@aueb.gr",
                        Phone = "+302108203911",
                        UniversityId = 2
                    }
                );

            //--------------------------------------------------------------------------------//

            builder
                .Entity<Department>()
                .HasData(
                    new Department
                    {
                        Id = 1,
                        Abbreviation = "pch",
                        Name = "Τμήμα Δημόσιας και Κοινοτικής Υγείας",
                        Website = "http://pch.uniwa.gr/",
                        Email = "pch@uniwa.gr",
                        Phone = "+302132010221",
                        FacultyId = 1
                    },
                    new Department
                    {
                        Id = 2,
                        Abbreviation = "php",
                        Name = "Τμήμα Πολιτικών Δημόσιας Υγείας",
                        Website = "http://php.uniwa.gr/",
                        Email = "php@uniwa.gr",
                        Phone = "+302132010207",
                        FacultyId = 1
                    },
                    new Department
                    {
                        Id = 3,
                        Abbreviation = "ecec",
                        Name = "Τμήμα Αγωγής και Φροντίδας στην Πρώιμη Παιδική Ηλικία",
                        Website = "http://ecec.uniwa.gr/",
                        Email = "ecec@uniwa.gr",
                        Phone = "+302105387092",
                        FacultyId = 2
                    },
                    new Department
                    {
                        Id = 4,
                        Abbreviation = "alis",
                        Name = "Τμήμα Αρχειονομίας, Βιβλιοθηκονομίας και Συστημάτων Πληροφόρησης",
                        Website = "http://alis.uniwa.gr/",
                        Email = "alis@uniwa.gr",
                        Phone = "+302105385203",
                        FacultyId = 2
                    },
                    new Department
                    {
                        Id = 5,
                        Abbreviation = "ba",
                        Name = "Τμήμα Διοίκησης Επιχειρήσεων",
                        Website = "http://ba.uniwa.gr/",
                        Email = "ba@uniwa.gr",
                        Phone = "+302105381151",
                        FacultyId = 2
                    },
                    new Department
                    {
                        Id = 6,
                        Abbreviation = "tourism",
                        Name = "Τμήμα Διοίκησης Τουρισμού",
                        Website = "http://tourism.uniwa.gr/",
                        Email = "tourism@uniwa.gr",
                        Phone = "+302105385211",
                        FacultyId = 2
                    },
                    new Department
                    {
                        Id = 7,
                        Abbreviation = "sw",
                        Name = "Τμήμα Κοινωνικής Εργασίας",
                        Website = "http://sw.uniwa.gr/",
                        Email = "sw@uniwa.gr",
                        Phone = "+302105381173",
                        FacultyId = 2
                    },
                    new Department
                    {
                        Id = 8,
                        Abbreviation = "accfin",
                        Name = "Τμήμα Λογιστικής και Χρηματοοικονομικής",
                        Website = "http://accfin.uniwa.gr/",
                        Email = "accfin@uniwa.gr",
                        Phone = "+302105381125",
                        FacultyId = 2
                    },
                    new Department
                    {
                        Id = 9,
                        Abbreviation = "fst",
                        Name = "Τμήμα Επιστήμης και Τεχνολογίας Τροφίμων",
                        Website = "http://fst.uniwa.gr/",
                        Email = "fst@uniwa.gr",
                        Phone = "+302105385506",
                        FacultyId = 3
                    },
                    new Department
                    {
                        Id = 10,
                        Abbreviation = "wvbs",
                        Name = "Τμήμα Επιστημών Οίνου, Αμπέλου και Ποτών",
                        Website = "http://wvbs.uniwa.gr/",
                        Email = "wvbs@uniwa.gr",
                        Phone = "+302105385538",
                        FacultyId = 3
                    },
                    new Department
                    {
                        Id = 11,
                        Abbreviation = "bisc",
                        Name = "Τμήμα Βιοϊατρικών Επιστημών",
                        Website = "http://bisc.uniwa.gr/",
                        Email = "bisc@uniwa.gr",
                        Phone = "+302105385690",
                        FacultyId = 4
                    },
                    new Department
                    {
                        Id = 12,
                        Abbreviation = "ot",
                        Name = "Τμήμα Εργοθεραπείας",
                        Website = "http://ot.uniwa.gr/",
                        Email = "ot@uniwa.gr",
                        Phone = "+302105387456",
                        FacultyId = 4
                    },
                    new Department
                    {
                        Id = 13,
                        Abbreviation = "midw",
                        Name = "Τμήμα Μαιευτικής",
                        Website = "http://midw.uniwa.gr/",
                        Email = "midw@uniwa.gr",
                        Phone = "+302105387481",
                        FacultyId = 4
                    },
                    new Department
                    {
                        Id = 14,
                        Abbreviation = "nurs",
                        Name = "Τμήμα Νοσηλευτικής",
                        Website = "http://nurs.uniwa.gr/",
                        Email = "nurs@uniwa.gr",
                        Phone = "+302105385616",
                        FacultyId = 4
                    },
                    new Department
                    {
                        Id = 15,
                        Abbreviation = "phys",
                        Name = "Τμήμα Φυσικοθεραπείας",
                        Website = "http://phys.uniwa.gr/",
                        Email = "phys@uniwa.gr",
                        Phone = "+302105387485",
                        FacultyId = 4
                    },
                    new Department
                    {
                        Id = 16,
                        Abbreviation = "gd",
                        Name = "Τμήμα Γραφιστικής και Οπτικής Επικοινωνίας",
                        Website = "http://gd.uniwa.gr/",
                        Email = "gd@uniwa.gr",
                        Phone = "+302105385466",
                        FacultyId = 5
                    },
                    new Department
                    {
                        Id = 17,
                        Abbreviation = "ia",
                        Name = "Τμήμα Εσωτερικής Αρχιτεκτονικής",
                        Website = "http://ia.uniwa.gr/",
                        Email = "decor@teiath.gr",
                        Phone = "+302105385405",
                        FacultyId = 5
                    },
                    new Department
                    {
                        Id = 18,
                        Abbreviation = "cons",
                        Name = "Τμήμα Συντήρησης Αρχαιοτήτων και Έργων Τέχνης",
                        Website = "http://cons.uniwa.gr/",
                        Email = "cons@uniwa.gr",
                        Phone = "+302105385462",
                        FacultyId = 5
                    },
                    new Department
                    {
                        Id = 19,
                        Abbreviation = "phaa",
                        Name = "Τμήμα Φωτογραφίας και Οπτικοακουστικών Τεχνών",
                        Website = "http://phaa.uniwa.gr/",
                        Email = "phaa@uniwa.gr",
                        Phone = "+302105385411",
                        FacultyId = 5
                    },
                    new Department
                    {
                        Id = 20,
                        Abbreviation = "eee",
                        Name = "Τμήμα Ηλεκτρολόγων και Ηλεκτρονικών Μηχανικών",
                        Website = "http://eee.uniwa.gr/",
                        Email = "eee@uniwa.gr",
                        Phone = "+302105381225",
                        FacultyId = 6
                    },
                    new Department
                    {
                        Id = 21,
                        Abbreviation = "bme",
                        Name = "Τμήμα Μηχανικών Βιοϊατρικής",
                        Website = "http://bme.uniwa.gr/",
                        Email = "bme@uniwa.gr",
                        Phone = "+302105385303",
                        FacultyId = 6
                    },
                    new Department
                    {
                        Id = 22,
                        Abbreviation = "idpe",
                        Name = "Τμήματος Μηχανικών Βιομηχανικής Σχεδίασης και Παραγωγής",
                        Website = "http://idpe.uniwa.gr/",
                        Email = "idpe@uniwa.gr",
                        Phone = "+302105381219",
                        FacultyId = 6
                    },
                    new Department
                    {
                        Id = 23,
                        Abbreviation = "ice",
                        Name = "Τμήμα Μηχανικών Πληροφορικής και Υπολογιστών",
                        Website = "http://ice.uniwa.gr/",
                        Email = "ice@uniwa.gr",
                        Phone = "+302105385382",
                        FacultyId = 6
                    },
                    new Department
                    {
                        Id = 24,
                        Abbreviation = "geo",
                        Name = "Τμήμα Μηχανικών Τοπογραφίας και Γεωπληροφορικής",
                        Website = "http://geo.uniwa.gr/",
                        Email = "geo@uniwa.gr",
                        Phone = "+302105385854",
                        FacultyId = 6
                    },
                    new Department
                    {
                        Id = 25,
                        Abbreviation = "mech",
                        Name = "Τμήμα Μηχανολόγων Μηχανικών",
                        Website = "http://mech.uniwa.gr/",
                        Email = "mech@uniwa.gr",
                        Phone = "+302105381506",
                        FacultyId = 6
                    },
                    new Department
                    {
                        Id = 26,
                        Abbreviation = "na",
                        Name = "Τμήμα Ναυπηγών Μηχανικών",
                        Website = "http://na.uniwa.gr/",
                        Email = "na@uniwa.gr",
                        Phone = "+302105385310",
                        FacultyId = 6
                    },
                    new Department
                    {
                        Id = 27,
                        Abbreviation = "civ",
                        Name = "Τμήμα Πολιτικών Μηχανικών",
                        Website = "http://civ.uniwa.gr/",
                        Email = "civ@uniwa.gr",
                        Phone = "+302105381215",
                        FacultyId = 6
                    },
                    new Department
                    {
                        Id = 28,
                        Abbreviation = "ode",
                        Name = "Τμήμα Οργάνωσης και Διοίκησης Επιχειρήσεων",
                        Website = "https://www.dept.aueb.gr/ode",
                        Email = "ode@aueb.gr",
                        Phone = "+302108203308",
                        FacultyId = 7
                    },
                    new Department
                    {
                        Id = 29,
                        Abbreviation = "mbv",
                        Name = "Τμήμα Μάρκετινγκ και Επικοινωνίας",
                        Website = "https://www.dept.aueb.gr/mbc",
                        Email = "secretary.marketing@aueb.gr",
                        Phone = "+302108203101",
                        FacultyId = 7
                    },
                    new Department
                    {
                        Id = 30,
                        Abbreviation = "loxri",
                        Name = "Τμήμα Λογιστικής και Χρηματοοικονομικής",
                        Website = "https://www.dept.aueb.gr/loxri",
                        Email = "accfin@aueb.gr",
                        Phone = "+302108203300",
                        FacultyId = 7
                    },
                    new Department
                    {
                        Id = 31,
                        Abbreviation = "dmst",
                        Name = "Τμήμα Διοικητικής Επιστήμης και Τεχνολογίας",
                        Website = "https://www.dept.aueb.gr/dmst",
                        Email = "dmst@aueb.gr",
                        Phone = "+302108203129",
                        FacultyId = 7
                    },
                    new Department
                    {
                        Id = 32,
                        Abbreviation = "econ",
                        Name = "Τμήμα Οικονομικής Επιστήμης",
                        Website = "https://www.dept.aueb.gr/econ",
                        Email = "econ@aueb.gr",
                        Phone = "+302108203303",
                        FacultyId = 8
                    },
                    new Department
                    {
                        Id = 33,
                        Abbreviation = "deos",
                        Name = "Τμήμα Διεθνών και Ευρωπαϊκών Οικονομικών Σπουδών",
                        Website = "https://www.dept.aueb.gr/deos",
                        Email = "deossecr@aueb.gr",
                        Phone = "+302108203106",
                        FacultyId = 8
                    },
                    new Department
                    {
                        Id = 34,
                        Abbreviation = "cs",
                        Name = "Τμήμα Πληροφορικής",
                        Website = "https://www.dept.aueb.gr/cs",
                        Email = "infotech@aueb.gr",
                        Phone = "+302108203315",
                        FacultyId = 9
                    },
                    new Department
                    {
                        Id = 35,
                        Abbreviation = "stat",
                        Name = "Τμήμα Στατιστικής",
                        Website = "https://www.dept.aueb.gr/stat",
                        Email = "stat@aueb.gr",
                        Phone = "+302108203112",
                        FacultyId = 9
                    }
                );
        }
    }
}
