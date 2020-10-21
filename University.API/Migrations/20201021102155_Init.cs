using Microsoft.EntityFrameworkCore.Migrations;

namespace University.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    UniversityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Abbreviation", "AccountId", "Address", "Name", "Phone", "Website" },
                values: new object[] { 1, "uniwa", 1, "Αγίου Σπυρίδωνος 28, Αιγάλεω 122 43", "Πανεπιστήμιο δυτικής αττικής", "+302105385100", "https://www.uniwa.gr" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Abbreviation", "AccountId", "Address", "Name", "Phone", "Website" },
                values: new object[] { 2, "uoa", 2, "Πανεπιστημίου 30, Αθήνα 106 79", "Εθνικό και Καποδιστριακό Πανεπιστήμιο Αθηνών", "+302107277000", "https://www.uoa.gr" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Abbreviation", "Email", "Name", "Phone", "UniversityId", "Website" },
                values: new object[,]
                {
                    { 1, "sph", "sph@uniwa.gr", "Σχολή Δημόσιας Υγείας", "+302132010115", 1, "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/sph/" },
                    { 2, "sdo", "sdoke@uniwa.gr", "Σχολή Διοικητικών, Οικονομικών & Κοινωνικών Επιστημών", "", 1, "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/sdo/" },
                    { 3, "ffs", "ffs@uniwa.gr", "Σχολή Επιστημών Τροφίμων", "2105385501", 1, "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/ffs/" },
                    { 4, "seyp", "seyp@uniwa.gr", "Σχολή Επιστημών Υγείας και Πρόνοιας", "2105385601", 1, "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/seyp/" },
                    { 5, "aac", "setp@uniwa.gr", "Σχολή Εφαρμοσμένων Τεχνών και Πολιτισμού", "2105385401", 1, "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/aac/" },
                    { 6, "feng", "feng@uniwa.gr", "Σχολή Μηχανικών", "+302105381212", 1, "https://www.uniwa.gr/spoydes/scholes-kai-tmimata/feng/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
