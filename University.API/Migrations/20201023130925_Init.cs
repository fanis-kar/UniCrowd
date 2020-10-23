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
                values: new object[] { 1, "uniwa", 1, "Αγίου Σπυρίδωνος 28, Αιγάλεω 122 43", "Πανεπιστήμιο Δυτικής Αττικής", "+302105385100", "https://www.uniwa.gr" });

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

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Abbreviation", "Email", "FacultyId", "Name", "Phone", "Website" },
                values: new object[,]
                {
                    { 1, "pch", "pch@uniwa.gr", 1, "Τμήμα Δημόσιας και Κοινοτικής Υγείας", "+302132010221", "http://pch.uniwa.gr/" },
                    { 25, "mech", "mech@uniwa.gr", 6, "Τμήμα Μηχανολόγων Μηχανικών", "+302105381506", "http://mech.uniwa.gr/" },
                    { 24, "geo", "geo@uniwa.gr", 6, "Τμήμα Μηχανικών Τοπογραφίας και Γεωπληροφορικής", "+302105385854", "http://geo.uniwa.gr/" },
                    { 23, "ice", "ice@uniwa.gr", 6, "Τμήμα Μηχανικών Πληροφορικής και Υπολογιστών", "+302105385382", "http://ice.uniwa.gr/" },
                    { 22, "idpe", "idpe@uniwa.gr", 6, "Τμήματος Μηχανικών Βιομηχανικής Σχεδίασης και Παραγωγής", "+302105381219", "http://idpe.uniwa.gr/" },
                    { 21, "bme", "bme@uniwa.gr", 6, "Τμήμα Μηχανικών Βιοϊατρικής", "+302105385303", "http://bme.uniwa.gr/" },
                    { 20, "eee", "eee@uniwa.gr", 6, "Τμήμα Ηλεκτρολόγων και Ηλεκτρονικών Μηχανικών", "+302105381225", "http://eee.uniwa.gr/" },
                    { 19, "phaa", "phaa@uniwa.gr", 5, "Τμήμα Φωτογραφίας και Οπτικοακουστικών Τεχνών", "+302105385411", "http://phaa.uniwa.gr/" },
                    { 18, "cons", "cons@uniwa.gr", 5, "Τμήμα Συντήρησης Αρχαιοτήτων και Έργων Τέχνης", "+302105385462", "http://cons.uniwa.gr/" },
                    { 17, "ia", "decor@teiath.gr", 5, "Τμήμα Εσωτερικής Αρχιτεκτονικής", "+302105385405", "http://ia.uniwa.gr/" },
                    { 16, "gd", "gd@uniwa.gr", 5, "Τμήμα Γραφιστικής και Οπτικής Επικοινωνίας", "+302105385466", "http://gd.uniwa.gr/" },
                    { 15, "phys", "phys@uniwa.gr", 4, "Τμήμα Φυσικοθεραπείας", "+302105387485", "http://phys.uniwa.gr/" },
                    { 26, "na", "na@uniwa.gr", 6, "Τμήμα Ναυπηγών Μηχανικών", "+302105385310", "http://na.uniwa.gr/" },
                    { 14, "nurs", "nurs@uniwa.gr", 4, "Τμήμα Νοσηλευτικής", "+302105385616", "http://nurs.uniwa.gr/" },
                    { 12, "ot", "ot@uniwa.gr", 4, "Τμήμα Εργοθεραπείας", "+302105387456", "http://ot.uniwa.gr/" },
                    { 11, "bisc", "bisc@uniwa.gr", 4, "Τμήμα Βιοϊατρικών Επιστημών", "+302105385690", "http://bisc.uniwa.gr/" },
                    { 10, "wvbs", "wvbs@uniwa.gr", 3, "Τμήμα Επιστημών Οίνου, Αμπέλου και Ποτών", "+302105385538", "http://wvbs.uniwa.gr/" },
                    { 9, "fst", "fst@uniwa.gr", 3, "Τμήμα Επιστήμης και Τεχνολογίας Τροφίμων", "+302105385506", "http://fst.uniwa.gr/" },
                    { 8, "accfin", "accfin@uniwa.gr", 2, "Τμήμα Λογιστικής και Χρηματοοικονομικής", "+302105381125", "http://accfin.uniwa.gr/" },
                    { 7, "sw", "sw@uniwa.gr", 2, "Τμήμα Κοινωνικής Εργασίας", "+302105381173", "http://sw.uniwa.gr/" },
                    { 6, "tourism", "tourism@uniwa.gr", 2, "Τμήμα Διοίκησης Τουρισμού", "+302105385211", "http://tourism.uniwa.gr/" },
                    { 5, "ba", "ba@uniwa.gr", 2, "Τμήμα Διοίκησης Επιχειρήσεων", "+302105381151", "http://ba.uniwa.gr/" },
                    { 4, "alis", "alis@uniwa.gr", 2, "Τμήμα Αρχειονομίας, Βιβλιοθηκονομίας και Συστημάτων Πληροφόρησης", "+302105385203", "http://alis.uniwa.gr/" },
                    { 3, "ecec", "ecec@uniwa.gr", 2, "Τμήμα Αγωγής και Φροντίδας στην Πρώιμη Παιδική Ηλικία", "+302105387092", "http://ecec.uniwa.gr/" },
                    { 2, "php", "php@uniwa.gr", 1, "Τμήμα Πολιτικών Δημόσιας Υγείας", "+302132010207", "http://php.uniwa.gr/" },
                    { 13, "midw", "midw@uniwa.gr", 4, "Τμήμα Μαιευτικής", "+302105387481", "http://midw.uniwa.gr/" },
                    { 27, "civ", "civ@uniwa.gr", 6, "Τμήμα Πολιτικών Μηχανικών", "+302105381215", "http://civ.uniwa.gr/" }
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
