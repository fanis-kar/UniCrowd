using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteer.API.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder
                .Entity<Model.Volunteer>()
                .HasData(
                    new Model.Volunteer
                    {
                        Id = 1,
                        FirstName = "Όνομα1",
                        LastName = "Επώνυμο1",
                        FatherName = "Πατρώνυμο1",
                        Phone = "2100000001",
                        Address = "Διεύθυνση Κατοικίας 1, Αθήνα 000 01",
                        AccountId = 3
                    },
                    new Model.Volunteer
                    {
                        Id = 2,
                        FirstName = "Όνομα2",
                        LastName = "Επώνυμο2",
                        FatherName = "Πατρώνυμο2",
                        Phone = "2100000002",
                        Address = "Διεύθυνση Κατοικίας 2, Αθήνα 000 02",
                        AccountId = 4
                    },
                    new Model.Volunteer
                    {
                        Id = 3,
                        FirstName = "Όνομα3",
                        LastName = "Επώνυμο3",
                        FatherName = "Πατρώνυμο3",
                        Phone = "2100000003",
                        Address = "Διεύθυνση Κατοικίας 3, Αθήνα 000 03",
                        AccountId = 5
                    },
                    new Model.Volunteer
                    {
                        Id = 4,
                        FirstName = "Όνομα4",
                        LastName = "Επώνυμο4",
                        FatherName = "Πατρώνυμο4",
                        Phone = "2100000004",
                        Address = "Διεύθυνση Κατοικίας 4, Αθήνα 000 04",
                        AccountId = 6
                    },
                    new Model.Volunteer
                    {
                        Id = 5,
                        FirstName = "Όνομα5",
                        LastName = "Επώνυμο5",
                        FatherName = "Πατρώνυμο5",
                        Phone = "2100000005",
                        Address = "Διεύθυνση Κατοικίας 5, Αθήνα 000 05",
                        AccountId = 7
                    },
                    new Model.Volunteer
                    {
                        Id = 6,
                        FirstName = "Όνομα6",
                        LastName = "Επώνυμο6",
                        FatherName = "Πατρώνυμο6",
                        Phone = "2100000006",
                        Address = "Διεύθυνση Κατοικίας 6, Αθήνα 000 06",
                        AccountId = 8
                    },
                    new Model.Volunteer
                    {
                        Id = 7,
                        FirstName = "Όνομα7",
                        LastName = "Επώνυμο7",
                        FatherName = "Πατρώνυμο7",
                        Phone = "2100000007",
                        Address = "Διεύθυνση Κατοικίας 7, Αθήνα 000 07",
                        AccountId = 9
                    },
                    new Model.Volunteer
                    {
                        Id = 8,
                        FirstName = "Όνομα8",
                        LastName = "Επώνυμο8",
                        FatherName = "Πατρώνυμο8",
                        Phone = "2100000008",
                        Address = "Διεύθυνση Κατοικίας 8, Αθήνα 000 08",
                        AccountId = 10
                    },
                    new Model.Volunteer
                    {
                        Id = 9,
                        FirstName = "Όνομα9",
                        LastName = "Επώνυμο9",
                        FatherName = "Πατρώνυμο9",
                        Phone = "2100000009",
                        Address = "Διεύθυνση Κατοικίας 9, Αθήνα 000 09",
                        AccountId = 11
                    },
                    new Model.Volunteer
                    {
                        Id = 10,
                        FirstName = "Όνομα10",
                        LastName = "Επώνυμο10",
                        FatherName = "Πατρώνυμο10",
                        Phone = "2100000010",
                        Address = "Διεύθυνση Κατοικίας 10, Αθήνα 000 10",
                        AccountId = 12
                    },
                    new Model.Volunteer
                    {
                        Id = 11,
                        FirstName = "Όνομα11",
                        LastName = "Επώνυμο11",
                        FatherName = "Πατρώνυμο11",
                        Phone = "2100000011",
                        Address = "Διεύθυνση Κατοικίας 11, Αθήνα 000 11",
                        AccountId = 13
                    },
                    new Model.Volunteer
                    {
                        Id = 12,
                        FirstName = "Όνομα12",
                        LastName = "Επώνυμο12",
                        FatherName = "Πατρώνυμο12",
                        Phone = "2100000012",
                        Address = "Διεύθυνση Κατοικίας 12, Αθήνα 000 12",
                        AccountId = 14
                    },
                    new Model.Volunteer
                    {
                        Id = 13,
                        FirstName = "Όνομα13",
                        LastName = "Επώνυμο13",
                        FatherName = "Πατρώνυμο13",
                        Phone = "2100000013",
                        Address = "Διεύθυνση Κατοικίας 13, Αθήνα 000 13",
                        AccountId = 15
                    },
                    new Model.Volunteer
                    {
                        Id = 14,
                        FirstName = "Όνομα14",
                        LastName = "Επώνυμο14",
                        FatherName = "Πατρώνυμο14",
                        Phone = "2100000014",
                        Address = "Διεύθυνση Κατοικίας 14, Αθήνα 000 14",
                        AccountId = 16
                    },
                    new Model.Volunteer
                    {
                        Id = 15,
                        FirstName = "Όνομα15",
                        LastName = "Επώνυμο15",
                        FatherName = "Πατρώνυμο15",
                        Phone = "2100000015",
                        Address = "Διεύθυνση Κατοικίας 15, Αθήνα 000 15",
                        AccountId = 17
                    },
                    new Model.Volunteer
                    {
                        Id = 16,
                        FirstName = "Όνομα16",
                        LastName = "Επώνυμο16",
                        FatherName = "Πατρώνυμο16",
                        Phone = "2100000016",
                        Address = "Διεύθυνση Κατοικίας 16, Αθήνα 000 16",
                        AccountId = 18
                    },
                    new Model.Volunteer
                    {
                        Id = 17,
                        FirstName = "Όνομα17",
                        LastName = "Επώνυμο17",
                        FatherName = "Πατρώνυμο17",
                        Phone = "2100000017",
                        Address = "Διεύθυνση Κατοικίας 17, Αθήνα 000 17",
                        AccountId = 19
                    },
                    new Model.Volunteer
                    {
                        Id = 18,
                        FirstName = "Όνομα18",
                        LastName = "Επώνυμο18",
                        FatherName = "Πατρώνυμο18",
                        Phone = "2100000018",
                        Address = "Διεύθυνση Κατοικίας 18, Αθήνα 000 18",
                        AccountId = 20
                    },
                    new Model.Volunteer
                    {
                        Id = 19,
                        FirstName = "Όνομα19",
                        LastName = "Επώνυμο19",
                        FatherName = "Πατρώνυμο19",
                        Phone = "2100000019",
                        Address = "Διεύθυνση Κατοικίας 19, Αθήνα 000 19",
                        AccountId = 21
                    },
                    new Model.Volunteer
                    {
                        Id = 20,
                        FirstName = "Όνομα20",
                        LastName = "Επώνυμο20",
                        FatherName = "Πατρώνυμο20",
                        Phone = "2100000020",
                        Address = "Διεύθυνση Κατοικίας 20, Αθήνα 000 20",
                        AccountId = 22
                    },
                    new Model.Volunteer
                    {
                        Id = 21,
                        FirstName = "Όνομα21",
                        LastName = "Επώνυμο21",
                        FatherName = "Πατρώνυμο21",
                        Phone = "2100000021",
                        Address = "Διεύθυνση Κατοικίας 21, Αθήνα 000 21",
                        AccountId = 23
                    },
                    new Model.Volunteer
                    {
                        Id = 22,
                        FirstName = "Όνομα22",
                        LastName = "Επώνυμο22",
                        FatherName = "Πατρώνυμο22",
                        Phone = "2100000022",
                        Address = "Διεύθυνση Κατοικίας 22, Αθήνα 000 22",
                        AccountId = 24
                    },
                    new Model.Volunteer
                    {
                        Id = 23,
                        FirstName = "Όνομα23",
                        LastName = "Επώνυμο23",
                        FatherName = "Πατρώνυμο23",
                        Phone = "2100000023",
                        Address = "Διεύθυνση Κατοικίας 23, Αθήνα 000 23",
                        AccountId = 25
                    },
                    new Model.Volunteer
                    {
                        Id = 24,
                        FirstName = "Όνομα24",
                        LastName = "Επώνυμο24",
                        FatherName = "Πατρώνυμο24",
                        Phone = "2100000024",
                        Address = "Διεύθυνση Κατοικίας 24, Αθήνα 000 24",
                        AccountId = 26
                    },
                    new Model.Volunteer
                    {
                        Id = 25,
                        FirstName = "Όνομα25",
                        LastName = "Επώνυμο25",
                        FatherName = "Πατρώνυμο25",
                        Phone = "2100000025",
                        Address = "Διεύθυνση Κατοικίας 25, Αθήνα 000 25",
                        AccountId = 27
                    },
                    new Model.Volunteer
                    {
                        Id = 26,
                        FirstName = "Όνομα26",
                        LastName = "Επώνυμο26",
                        FatherName = "Πατρώνυμο26",
                        Phone = "2100000026",
                        Address = "Διεύθυνση Κατοικίας 26, Αθήνα 000 26",
                        AccountId = 28
                    },
                    new Model.Volunteer
                    {
                        Id = 27,
                        FirstName = "Όνομα27",
                        LastName = "Επώνυμο27",
                        FatherName = "Πατρώνυμο27",
                        Phone = "2100000027",
                        Address = "Διεύθυνση Κατοικίας 27, Αθήνα 000 27",
                        AccountId = 29
                    },
                    new Model.Volunteer
                    {
                        Id = 28,
                        FirstName = "Όνομα28",
                        LastName = "Επώνυμο28",
                        FatherName = "Πατρώνυμο28",
                        Phone = "2100000028",
                        Address = "Διεύθυνση Κατοικίας 28, Αθήνα 000 28",
                        AccountId = 30
                    },
                    new Model.Volunteer
                    {
                        Id = 29,
                        FirstName = "Όνομα29",
                        LastName = "Επώνυμο29",
                        FatherName = "Πατρώνυμο29",
                        Phone = "2100000029",
                        Address = "Διεύθυνση Κατοικίας 29, Αθήνα 000 29",
                        AccountId = 31
                    },
                    new Model.Volunteer
                    {
                        Id = 30,
                        FirstName = "Όνομα30",
                        LastName = "Επώνυμο30",
                        FatherName = "Πατρώνυμο30",
                        Phone = "2100000030",
                        Address = "Διεύθυνση Κατοικίας 30, Αθήνα 000 30",
                        AccountId = 32
                    }
                );
        }
    }
}
