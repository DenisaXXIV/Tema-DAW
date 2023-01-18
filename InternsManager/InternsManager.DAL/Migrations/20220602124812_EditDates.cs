using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternsManager.DAL.Migrations
{
    public partial class EditDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 1,
                column: "DateOfBirth",
                value: "2002-05-04");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 2,
                column: "DateOfBirth",
                value: "1990-11-12");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 3,
                column: "DateOfBirth",
                value: "2002-02-23");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 4,
                column: "DateOfBirth",
                value: "2002-02-02");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 5,
                column: "DateOfBirth",
                value: "2000-09-05");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 6,
                column: "DateOfBirth",
                value: "2001-11-29");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 1,
                column: "DateOfBirth",
                value: "4.05.2002");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 2,
                column: "DateOfBirth",
                value: "12.11.1990");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 3,
                column: "DateOfBirth",
                value: "23.02.2002");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 4,
                column: "DateOfBirth",
                value: "02.04.2002");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 5,
                column: "DateOfBirth",
                value: "05.09.2000");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "IdPerson",
                keyValue: 6,
                column: "DateOfBirth",
                value: "29.11.20001");
        }
    }
}
