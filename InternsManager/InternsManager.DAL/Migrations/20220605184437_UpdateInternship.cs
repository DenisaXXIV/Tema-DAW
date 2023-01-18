using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternsManager.DAL.Migrations
{
    public partial class UpdateInternship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "IdInternship",
                keyValue: 1,
                columns: new[] { "EndDate", "Position", "StartDate" },
                values: new object[] { "2022-07-14", "Software Engineer", "2022-06-01" });

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "IdInternship",
                keyValue: 2,
                columns: new[] { "EndDate", "Position", "StartDate" },
                values: new object[] { "2022-08-22", "QA", "2022-05-23" });

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "IdInternship",
                keyValue: 3,
                columns: new[] { "EndDate", "Position", "StartDate" },
                values: new object[] { "2022-09-14", "Web Develover", "2022-06-15" });

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "IdInternship",
                keyValue: 4,
                columns: new[] { "EndDate", "Position", "StartDate" },
                values: new object[] { "2022-09-19", "Junior Programmer", "2022-06-20" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "IdInternship",
                keyValue: 1,
                columns: new[] { "EndDate", "Position", "StartDate" },
                values: new object[] { "1.07.2022", "Software Engineer Intern", "1.06.2022" });

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "IdInternship",
                keyValue: 2,
                columns: new[] { "EndDate", "Position", "StartDate" },
                values: new object[] { "22.08.2022", "QA Intern", "23.05.2022" });

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "IdInternship",
                keyValue: 3,
                columns: new[] { "EndDate", "Position", "StartDate" },
                values: new object[] { "14.09.2022", "Web Develover Intern", "15.06.2022" });

            migrationBuilder.UpdateData(
                table: "Internships",
                keyColumn: "IdInternship",
                keyValue: 4,
                columns: new[] { "EndDate", "Position", "StartDate" },
                values: new object[] { "19.09.2022", "Junior Programmer Intern", "20.06.2022" });
        }
    }
}
