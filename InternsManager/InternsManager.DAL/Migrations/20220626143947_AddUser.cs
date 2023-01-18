using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternsManager.DAL.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IdAdmin);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "IdAdmin", "IdPerson", "Password", "Username" },
                values: new object[] { 1, 7, "$2a$11$oxugnHJQ1NUogyxXyN5tEedqgTmNFSYw.WBBVER5UVOSFsaathz3y", "SNeagu" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "IdPerson", "DateOfBirth", "Gender", "Name", "PicPath" },
                values: new object[] { 7, "1977-03-07", "F", "Stefania Neagu", "https://pixabay.com/get/gffc1d520603515ef286493847cebeab3b46d1b6e29250bceac008431920a5570bd6cc874b1efe2e58a3e766271af1e9329582245e58ae87739687318cae97df6a4e690a31d0245e9ff5b808edc166aa6_1920.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 7);
        }
    }
}
