using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    AccountId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LeaderId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Volunteers_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "AccountId", "Address", "FatherName", "FirstName", "GroupId", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, 3, "Διεύθυνση Κατοικίας 1, Αθήνα 000 01", "Πατρώνυμο1", "Όνομα1", null, "Επώνυμο1", "2100000001" },
                    { 28, 30, "Διεύθυνση Κατοικίας 28, Αθήνα 000 28", "Πατρώνυμο28", "Όνομα28", null, "Επώνυμο28", "2100000028" },
                    { 27, 29, "Διεύθυνση Κατοικίας 27, Αθήνα 000 27", "Πατρώνυμο27", "Όνομα27", null, "Επώνυμο27", "2100000027" },
                    { 26, 28, "Διεύθυνση Κατοικίας 26, Αθήνα 000 26", "Πατρώνυμο26", "Όνομα26", null, "Επώνυμο26", "2100000026" },
                    { 25, 27, "Διεύθυνση Κατοικίας 25, Αθήνα 000 25", "Πατρώνυμο25", "Όνομα25", null, "Επώνυμο25", "2100000025" },
                    { 24, 26, "Διεύθυνση Κατοικίας 24, Αθήνα 000 24", "Πατρώνυμο24", "Όνομα24", null, "Επώνυμο24", "2100000024" },
                    { 23, 25, "Διεύθυνση Κατοικίας 23, Αθήνα 000 23", "Πατρώνυμο23", "Όνομα23", null, "Επώνυμο23", "2100000023" },
                    { 22, 24, "Διεύθυνση Κατοικίας 22, Αθήνα 000 22", "Πατρώνυμο22", "Όνομα22", null, "Επώνυμο22", "2100000022" },
                    { 21, 23, "Διεύθυνση Κατοικίας 21, Αθήνα 000 21", "Πατρώνυμο21", "Όνομα21", null, "Επώνυμο21", "2100000021" },
                    { 20, 22, "Διεύθυνση Κατοικίας 20, Αθήνα 000 20", "Πατρώνυμο20", "Όνομα20", null, "Επώνυμο20", "2100000020" },
                    { 19, 21, "Διεύθυνση Κατοικίας 19, Αθήνα 000 19", "Πατρώνυμο19", "Όνομα19", null, "Επώνυμο19", "2100000019" },
                    { 18, 20, "Διεύθυνση Κατοικίας 18, Αθήνα 000 18", "Πατρώνυμο18", "Όνομα18", null, "Επώνυμο18", "2100000018" },
                    { 17, 19, "Διεύθυνση Κατοικίας 17, Αθήνα 000 17", "Πατρώνυμο17", "Όνομα17", null, "Επώνυμο17", "2100000017" },
                    { 16, 18, "Διεύθυνση Κατοικίας 16, Αθήνα 000 16", "Πατρώνυμο16", "Όνομα16", null, "Επώνυμο16", "2100000016" },
                    { 15, 17, "Διεύθυνση Κατοικίας 15, Αθήνα 000 15", "Πατρώνυμο15", "Όνομα15", null, "Επώνυμο15", "2100000015" },
                    { 14, 16, "Διεύθυνση Κατοικίας 14, Αθήνα 000 14", "Πατρώνυμο14", "Όνομα14", null, "Επώνυμο14", "2100000014" },
                    { 13, 15, "Διεύθυνση Κατοικίας 13, Αθήνα 000 13", "Πατρώνυμο13", "Όνομα13", null, "Επώνυμο13", "2100000013" },
                    { 12, 14, "Διεύθυνση Κατοικίας 12, Αθήνα 000 12", "Πατρώνυμο12", "Όνομα12", null, "Επώνυμο12", "2100000012" },
                    { 11, 13, "Διεύθυνση Κατοικίας 11, Αθήνα 000 11", "Πατρώνυμο11", "Όνομα11", null, "Επώνυμο11", "2100000011" },
                    { 10, 12, "Διεύθυνση Κατοικίας 10, Αθήνα 000 10", "Πατρώνυμο10", "Όνομα10", null, "Επώνυμο10", "2100000010" },
                    { 9, 11, "Διεύθυνση Κατοικίας 9, Αθήνα 000 09", "Πατρώνυμο9", "Όνομα9", null, "Επώνυμο9", "2100000009" },
                    { 8, 10, "Διεύθυνση Κατοικίας 8, Αθήνα 000 08", "Πατρώνυμο8", "Όνομα8", null, "Επώνυμο8", "2100000008" },
                    { 7, 9, "Διεύθυνση Κατοικίας 7, Αθήνα 000 07", "Πατρώνυμο7", "Όνομα7", null, "Επώνυμο7", "2100000007" },
                    { 6, 8, "Διεύθυνση Κατοικίας 6, Αθήνα 000 06", "Πατρώνυμο6", "Όνομα6", null, "Επώνυμο6", "2100000006" },
                    { 5, 7, "Διεύθυνση Κατοικίας 5, Αθήνα 000 05", "Πατρώνυμο5", "Όνομα5", null, "Επώνυμο5", "2100000005" },
                    { 4, 6, "Διεύθυνση Κατοικίας 4, Αθήνα 000 04", "Πατρώνυμο4", "Όνομα4", null, "Επώνυμο4", "2100000004" },
                    { 3, 5, "Διεύθυνση Κατοικίας 3, Αθήνα 000 03", "Πατρώνυμο3", "Όνομα3", null, "Επώνυμο3", "2100000003" },
                    { 2, 4, "Διεύθυνση Κατοικίας 2, Αθήνα 000 02", "Πατρώνυμο2", "Όνομα2", null, "Επώνυμο2", "2100000002" },
                    { 29, 31, "Διεύθυνση Κατοικίας 29, Αθήνα 000 29", "Πατρώνυμο29", "Όνομα29", null, "Επώνυμο29", "2100000029" },
                    { 30, 32, "Διεύθυνση Κατοικίας 30, Αθήνα 000 30", "Πατρώνυμο30", "Όνομα30", null, "Επώνυμο30", "2100000030" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_LeaderId",
                table: "Groups",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_GroupId",
                table: "Volunteers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Groups_GroupId",
                table: "Volunteers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Volunteers_LeaderId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
