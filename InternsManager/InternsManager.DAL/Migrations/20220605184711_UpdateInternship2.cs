using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternsManager.DAL.Migrations
{
    public partial class UpdateInternship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
    table: "Internships",
    columns: new[] { "IdInternship", "EndDate", "Name", "Position", "SalaryBRUT", "StartDate" },
    values: new object[,]
    {
                    { 1, "2022-07-01", "DiscoverIT", "Software Engineer Intern", "1500 Lei", "2022-06-01" },
                    { 2, "2022-08-22", "QA Internship", "QA Intern", "1750 Lei", "2022-05-23" },
                    { 3, "2022-09-14", "TriangleXperience", "Web Develover Intern", "1500 Lei", "2022-06-15" },
                    { 4, "2022-09-19", "TetraTech", "Junior Programmer Intern", "1620 Lei", "2022-06-20" }
    });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
