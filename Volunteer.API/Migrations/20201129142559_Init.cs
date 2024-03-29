﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Volunteer.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Stars = table.Column<float>(nullable: true),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "AccountId", "Address", "FatherName", "FirstName", "LastName", "Phone", "Stars" },
                values: new object[,]
                {
                    { 1, 3, "Διεύθυνση Κατοικίας 1, Αθήνα 000 01", "Πατρώνυμο1", "Όνομα1", "Επώνυμο1", "2100000001", null },
                    { 28, 30, "Διεύθυνση Κατοικίας 28, Αθήνα 000 28", "Πατρώνυμο28", "Όνομα28", "Επώνυμο28", "2100000028", null },
                    { 27, 29, "Διεύθυνση Κατοικίας 27, Αθήνα 000 27", "Πατρώνυμο27", "Όνομα27", "Επώνυμο27", "2100000027", null },
                    { 26, 28, "Διεύθυνση Κατοικίας 26, Αθήνα 000 26", "Πατρώνυμο26", "Όνομα26", "Επώνυμο26", "2100000026", null },
                    { 25, 27, "Διεύθυνση Κατοικίας 25, Αθήνα 000 25", "Πατρώνυμο25", "Όνομα25", "Επώνυμο25", "2100000025", null },
                    { 24, 26, "Διεύθυνση Κατοικίας 24, Αθήνα 000 24", "Πατρώνυμο24", "Όνομα24", "Επώνυμο24", "2100000024", null },
                    { 23, 25, "Διεύθυνση Κατοικίας 23, Αθήνα 000 23", "Πατρώνυμο23", "Όνομα23", "Επώνυμο23", "2100000023", null },
                    { 22, 24, "Διεύθυνση Κατοικίας 22, Αθήνα 000 22", "Πατρώνυμο22", "Όνομα22", "Επώνυμο22", "2100000022", null },
                    { 21, 23, "Διεύθυνση Κατοικίας 21, Αθήνα 000 21", "Πατρώνυμο21", "Όνομα21", "Επώνυμο21", "2100000021", null },
                    { 20, 22, "Διεύθυνση Κατοικίας 20, Αθήνα 000 20", "Πατρώνυμο20", "Όνομα20", "Επώνυμο20", "2100000020", null },
                    { 19, 21, "Διεύθυνση Κατοικίας 19, Αθήνα 000 19", "Πατρώνυμο19", "Όνομα19", "Επώνυμο19", "2100000019", null },
                    { 18, 20, "Διεύθυνση Κατοικίας 18, Αθήνα 000 18", "Πατρώνυμο18", "Όνομα18", "Επώνυμο18", "2100000018", null },
                    { 17, 19, "Διεύθυνση Κατοικίας 17, Αθήνα 000 17", "Πατρώνυμο17", "Όνομα17", "Επώνυμο17", "2100000017", null },
                    { 16, 18, "Διεύθυνση Κατοικίας 16, Αθήνα 000 16", "Πατρώνυμο16", "Όνομα16", "Επώνυμο16", "2100000016", null },
                    { 15, 17, "Διεύθυνση Κατοικίας 15, Αθήνα 000 15", "Πατρώνυμο15", "Όνομα15", "Επώνυμο15", "2100000015", null },
                    { 14, 16, "Διεύθυνση Κατοικίας 14, Αθήνα 000 14", "Πατρώνυμο14", "Όνομα14", "Επώνυμο14", "2100000014", null },
                    { 13, 15, "Διεύθυνση Κατοικίας 13, Αθήνα 000 13", "Πατρώνυμο13", "Όνομα13", "Επώνυμο13", "2100000013", null },
                    { 12, 14, "Διεύθυνση Κατοικίας 12, Αθήνα 000 12", "Πατρώνυμο12", "Όνομα12", "Επώνυμο12", "2100000012", null },
                    { 11, 13, "Διεύθυνση Κατοικίας 11, Αθήνα 000 11", "Πατρώνυμο11", "Όνομα11", "Επώνυμο11", "2100000011", null },
                    { 10, 12, "Διεύθυνση Κατοικίας 10, Αθήνα 000 10", "Πατρώνυμο10", "Όνομα10", "Επώνυμο10", "2100000010", null },
                    { 9, 11, "Διεύθυνση Κατοικίας 9, Αθήνα 000 09", "Πατρώνυμο9", "Όνομα9", "Επώνυμο9", "2100000009", null },
                    { 8, 10, "Διεύθυνση Κατοικίας 8, Αθήνα 000 08", "Πατρώνυμο8", "Όνομα8", "Επώνυμο8", "2100000008", null },
                    { 7, 9, "Διεύθυνση Κατοικίας 7, Αθήνα 000 07", "Πατρώνυμο7", "Όνομα7", "Επώνυμο7", "2100000007", null },
                    { 6, 8, "Διεύθυνση Κατοικίας 6, Αθήνα 000 06", "Πατρώνυμο6", "Όνομα6", "Επώνυμο6", "2100000006", null },
                    { 5, 7, "Διεύθυνση Κατοικίας 5, Αθήνα 000 05", "Πατρώνυμο5", "Όνομα5", "Επώνυμο5", "2100000005", null },
                    { 4, 6, "Διεύθυνση Κατοικίας 4, Αθήνα 000 04", "Πατρώνυμο4", "Όνομα4", "Επώνυμο4", "2100000004", null },
                    { 3, 5, "Διεύθυνση Κατοικίας 3, Αθήνα 000 03", "Πατρώνυμο3", "Όνομα3", "Επώνυμο3", "2100000003", null },
                    { 2, 4, "Διεύθυνση Κατοικίας 2, Αθήνα 000 02", "Πατρώνυμο2", "Όνομα2", "Επώνυμο2", "2100000002", null },
                    { 29, 31, "Διεύθυνση Κατοικίας 29, Αθήνα 000 29", "Πατρώνυμο29", "Όνομα29", "Επώνυμο29", "2100000029", null },
                    { 30, 32, "Διεύθυνση Κατοικίας 30, Αθήνα 000 30", "Πατρώνυμο30", "Όνομα30", "Επώνυμο30", "2100000030", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteers");
        }
    }
}
