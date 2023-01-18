using InternsManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bCrypt = BCrypt.Net.BCrypt;

namespace InternsManager.DAL.Migrations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    IdPerson = 1,
                    Name = "Alexandru Ivanoff",
                    DateOfBirth = "2002-05-04",
                    Gender = "M",
                    PicPath = "https://cdn.pixabay.com/photo/2017/11/26/00/30/teen-2977908_960_720.jpg"
                },
                new Person
                {
                    IdPerson = 2,
                    Name = "Irina Defta",
                    DateOfBirth = "1990-11-12",
                    Gender = "F",
                    PicPath = "https://cdn.pixabay.com/photo/2015/03/03/18/58/woman-657753_1280.jpg"
                },
                new Person
                {
                    IdPerson = 3,
                    Name = "Florian-Andrei Barbu",
                    DateOfBirth = "2002-02-23",
                    Gender = "M",
                    PicPath = "https://cdn.pixabay.com/photo/2016/03/04/21/24/portrait-1236732_1280.jpg"
                },
                new Person
                {
                    IdPerson = 4,
                    Name = "Augustin Petrica",
                    DateOfBirth = "2002-02-02",
                    Gender = "M",
                    PicPath = "https://cdn.pixabay.com/photo/2020/03/01/22/43/young-4894362_1280.jpg"
                },
                 new Person
                 {
                     IdPerson = 5,
                     Name = "Oana Cretu",
                     DateOfBirth = "2000-09-05",
                     Gender = "F",
                     PicPath = "https://cdn.pixabay.com/photo/2018/08/03/16/14/young-girl-3582188_1280.jpg"
                 },
                 new Person
                 {
                     IdPerson = 6,
                     Name = "Ema Drobescu",
                     DateOfBirth = "2001-11-29",
                     Gender = "F",
                     PicPath = "https://cdn.pixabay.com/photo/2017/08/28/16/29/portrait-2690308_1280.jpg"
                 },
                 new Person
                 {
                     IdPerson = 7,
                     Name = "Stefania Neagu",
                     DateOfBirth = "1977-03-07",
                     Gender = "F",
                     PicPath = "https://pixabay.com/get/gffc1d520603515ef286493847cebeab3b46d1b6e29250bceac008431920a5570bd6cc874b1efe2e58a3e766271af1e9329582245e58ae87739687318cae97df6a4e690a31d0245e9ff5b808edc166aa6_1920.jpg"
                 });

            modelBuilder.Entity<Intern>().HasData(
                 new Intern
                 {
                     IdIntern = 1,
                     IdPerson = 1,
                     IdInternship = 1,
                     VacationDays = 28
                 },
                 new Intern
                 {
                     IdIntern = 2,
                     IdPerson = 2,
                     IdInternship = 2,
                     VacationDays = 26
                 },
                 new Intern
                 {
                     IdIntern = 3,
                     IdPerson = 3,
                     IdInternship = 3,
                     VacationDays = 28,
                 },
                 new Intern
                 {
                     IdIntern = 4,
                     IdPerson = 4,
                     IdInternship = 4,
                     VacationDays = 28,
                 },
                 new Intern
                 {
                     IdIntern = 5,
                     IdPerson = 5,
                     IdInternship = 4,
                     VacationDays = 28,
                 },
                 new Intern
                 {
                     IdIntern = 6,
                     IdPerson = 6,
                     IdInternship = 3,
                     VacationDays = 28,
                 });

            modelBuilder.Entity<Internship>().HasData(
                new Internship
                {
                    IdInternship = 1,
                    Name = "DiscoverIT",
                    StartDate = "2022-06-01",
                    EndDate = "2022-07-14",
                    SalaryBRUT = "1500 Lei",
                    Position = "Software Engineer"
                },
                new Internship
                {
                    IdInternship = 2,
                    Name = "QA Internship",
                    StartDate = "2022-05-23",
                    EndDate = "2022-08-22",
                    SalaryBRUT = "1750 Lei",
                    Position = "QA"
                },
                new Internship
                {
                    IdInternship = 3,
                    Name = "TriangleXperience",
                    StartDate = "2022-06-15",
                    EndDate = "2022-09-14",
                    SalaryBRUT = "1500 Lei",
                    Position = "Web Develover"
                },
                new Internship
                {
                    IdInternship = 4,
                    Name = "TetraTech",
                    StartDate = "2022-06-20",
                    EndDate = "2022-09-19",
                    SalaryBRUT = "1620 Lei",
                    Position = "Junior Programmer"
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    IdUser = 1,
                    IdPerson = 7,
                    Username = "SNeagu",
                    Mail = "sneagu@manager.ro",
                    IdRole = 1,
                    Password = bCrypt.HashPassword("admin1").ToString()
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    IdRole = 1,
                    RoleName = "Admin",
                },
                new Role
                {
                    IdRole = 2,
                    RoleName = "Intern",
                },
                new Role
                {
                    IdRole = 3,
                    RoleName = "Employee",
                });
        }
    }
}
