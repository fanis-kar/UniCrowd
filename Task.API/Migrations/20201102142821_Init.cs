using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolunteersSkills",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteersSkills", x => new { x.VolunteerId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_VolunteersSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    VolunteerNumber = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    UniversityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Stars = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Decision = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    VolunteerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invitations_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TasksSkills",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksSkills", x => new { x.TaskId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_TasksSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TasksSkills_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteersGroups",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteersGroups", x => new { x.VolunteerId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_VolunteersGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Μη διαθέσιμη", "Βασικές γνώσεις Η/Υ" },
                    { 17, "Μη διαθέσιμη", "Αγγλικά - Άριστη γνώση (Γ2)" },
                    { 16, "Μη διαθέσιμη", "Αγγλικά - Πολύ καλή γνώση (Γ1)" },
                    { 15, "Μη διαθέσιμη", "Αγγλικά - Καλή γνώση (B2)" },
                    { 14, "Μη διαθέσιμη", "MySQL" },
                    { 13, "Μη διαθέσιμη", "MongoDB" },
                    { 12, "Μη διαθέσιμη", "SQL Server" },
                    { 10, "Μη διαθέσιμη", "Εξόρυξη δεδομένων" },
                    { 11, "Μη διαθέσιμη", "Διαχείριση δεδομένων μεγάλης κλίμακας" },
                    { 8, "Μη διαθέσιμη", "Ανάπτυξη WEB εφαρμογών με Xamarin Forms" },
                    { 7, "Μη διαθέσιμη", "Ανάπτυξη mobile εφαρμογών με JAVA" },
                    { 6, "Μη διαθέσιμη", "Ανάπτυξη WEB εφαρμογών με C#" },
                    { 5, "Μη διαθέσιμη", "Ανάπτυξη WEB εφαρμογών με JAVA" },
                    { 4, "Μη διαθέσιμη", "Προγραμματισμός με Python" },
                    { 3, "Μη διαθέσιμη", "Προγραμματισμός με C#" },
                    { 2, "Μη διαθέσιμη", "Προγραμματισμός με JAVA" },
                    { 9, "Μη διαθέσιμη", "Μηχανική μάθηση" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "3. ΟΛΟΚΛΗΡΩΜΕΝΟ TASK" },
                    { 1, "1. ΔΗΜΙΟΥΡΓΙΑ GROUP" },
                    { 2, "2. ΕΝΕΡΓΟ TASK" },
                    { 4, "4. ΑΚΥΡΩΜΕΝΟ TASK" }
                });

            migrationBuilder.InsertData(
                table: "VolunteersSkills",
                columns: new[] { "VolunteerId", "SkillId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 6 },
                    { 1, 8 },
                    { 1, 12 },
                    { 1, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TaskId",
                table: "Groups",
                column: "TaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_TaskId",
                table: "Invitations",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksSkills_SkillId",
                table: "TasksSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersGroups_GroupId",
                table: "VolunteersGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersSkills_SkillId",
                table: "VolunteersSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "TasksSkills");

            migrationBuilder.DropTable(
                name: "VolunteersGroups");

            migrationBuilder.DropTable(
                name: "VolunteersSkills");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
