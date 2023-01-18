using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternsManager.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    IdIntern = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    IdInternship = table.Column<int>(type: "int", nullable: false),
                    VacationDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.IdIntern);
                });

            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    IdInternship = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryBRUT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.IdInternship);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PicPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.IdPerson);
                });

            migrationBuilder.InsertData(
                table: "Interns",
                columns: new[] { "IdIntern", "IdInternship", "IdPerson", "VacationDays" },
                values: new object[,]
                {
                    { 1, 1, 1, 28 },
                    { 2, 2, 2, 26 },
                    { 3, 3, 3, 28 },
                    { 4, 4, 4, 28 },
                    { 5, 4, 5, 28 },
                    { 6, 3, 6, 28 }
                });

            migrationBuilder.InsertData(
                table: "Internships",
                columns: new[] { "IdInternship", "EndDate", "Name", "Position", "SalaryBRUT", "StartDate" },
                values: new object[,]
                {
                    { 1, "1.07.2022", "DiscoverIT", "Software Engineer Intern", "1500 Lei", "1.06.2022" },
                    { 2, "22.08.2022", "QA Internship", "QA Intern", "1750 Lei", "23.05.2022" },
                    { 3, "14.09.2022", "TriangleXperience", "Web Develover Intern", "1500 Lei", "15.06.2022" },
                    { 4, "19.09.2022", "TetraTech", "Junior Programmer Intern", "1620 Lei", "20.06.2022" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "IdPerson", "DateOfBirth", "Gender", "Name", "PicPath" },
                values: new object[,]
                {
                    { 1, "4.05.2002", "M", "Alexandru Ivanoff", "https://cdn.pixabay.com/photo/2017/11/26/00/30/teen-2977908_960_720.jpg" },
                    { 2, "12.11.1990", "F", "Irina Defta", "https://cdn.pixabay.com/photo/2015/03/03/18/58/woman-657753_1280.jpg" },
                    { 3, "23.02.2002", "M", "Florian-Andrei Barbu", "https://cdn.pixabay.com/photo/2016/03/04/21/24/portrait-1236732_1280.jpg" },
                    { 4, "02.04.2002", "M", "Augustin Petrica", "https://cdn.pixabay.com/photo/2020/03/01/22/43/young-4894362_1280.jpg" },
                    { 5, "05.09.2000", "F", "Oana Cretu", "https://cdn.pixabay.com/photo/2018/08/03/16/14/young-girl-3582188_1280.jpg" },
                    { 6, "29.11.20001", "F", "Ema Drobescu", "https://cdn.pixabay.com/photo/2017/08/28/16/29/portrait-2690308_1280.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interns");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
