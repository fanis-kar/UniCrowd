using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentication.API.Migrations
{
    public partial class Iniy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "University" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Volunteer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RoleId", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, "info@uniwa.gr", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 1, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "uniwa" },
                    { 30, "volunteer28@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer28" },
                    { 29, "volunteer27@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer27" },
                    { 28, "volunteer26@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer26" },
                    { 27, "volunteer25@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer25" },
                    { 26, "volunteer24@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer24" },
                    { 25, "volunteer23@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer23" },
                    { 24, "volunteer22@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer22" },
                    { 23, "volunteer21@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer21" },
                    { 22, "volunteer20@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer20" },
                    { 21, "volunteer19@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer19" },
                    { 20, "volunteer18@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer18" },
                    { 19, "volunteer17@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer17" },
                    { 18, "volunteer16@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer16" },
                    { 17, "volunteer15@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer15" },
                    { 16, "volunteer14@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer14" },
                    { 15, "volunteer13@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer13" },
                    { 14, "volunteer12@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer12" },
                    { 13, "volunteer11@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer11" },
                    { 12, "volunteer10@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer10" },
                    { 11, "volunteer9@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer9" },
                    { 10, "volunteer8@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer8" },
                    { 9, "volunteer7@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer7" },
                    { 8, "volunteer6@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer6" },
                    { 7, "volunteer5@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer5" },
                    { 6, "volunteer4@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer4" },
                    { 5, "volunteer3@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer3" },
                    { 4, "volunteer2@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer2" },
                    { 3, "volunteer1@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer1" },
                    { 2, "webmaster@aueb.gr", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 1, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "aueb" },
                    { 31, "volunteer29@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer29" },
                    { 32, "volunteer30@mail.com", "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==", 2, "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==", "volunteer30" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
