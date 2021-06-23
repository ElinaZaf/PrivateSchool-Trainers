namespace Assignment2_ElinaZafeiri.Migrations
{
    using Assignment2_ElinaZafeiri.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment2_ElinaZafeiri.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Assignment2_ElinaZafeiri.DAL.ApplicationDbContext context)
        {
           
            //=================Seeding Subjects=================
            Subject s1 = new Subject() { Title = "C#" };
            Subject s2 = new Subject() { Title = "Java" };
            Subject s3 = new Subject() { Title = "Python" };
            Subject s4 = new Subject() { Title = "JavaScript" };
            Subject s5 = new Subject() { Title = "SQL" };
            Subject s6 = new Subject() { Title = "C++" };

            //=================Seeding Trainers=================
            Trainer t1 = new Trainer() { FirstName = "Antony", LastName = "Doyle", Salary = 40000.00M, HireDate = new DateTime(2019, 09, 11), isAvailable = true };
            t1.Subjects = new List<Subject>() { s1, s6 };
            Trainer t2 = new Trainer() { FirstName = "Charles", LastName = "Wallace", Salary = 50000.00M, HireDate = new DateTime(2020, 08, 15), isAvailable = false };
            t2.Subjects = new List<Subject>() { s1, s2, s3 };
            Trainer t3 = new Trainer() { FirstName = "Agatha", LastName = "Brown", Salary = 60000.00M, HireDate = new DateTime(2018, 07, 03), isAvailable = false };
            t3.Subjects = new List<Subject>() { s3, s4 };
            Trainer t4 = new Trainer() { FirstName = "Daniel", LastName = "Morisson", Salary = 70000.00M, HireDate = new DateTime(2017, 06, 21), isAvailable = true };
            t4.Subjects = new List<Subject>() { s2, s3, s4, s6 };
            Trainer t5 = new Trainer() { FirstName = "Ella", LastName = "Dickens", Salary = 80000.00M, HireDate = new DateTime(2021, 06, 22), isAvailable = true };
            t5.Subjects = new List<Subject>() { s1, s3, s4, s5 };
            Trainer t6 = new Trainer() { FirstName = "Michael", LastName = "Thompson", Salary = 30000.00M, HireDate = new DateTime(2017, 04, 18), isAvailable = false };
            t6.Subjects = new List<Subject>() { s4, s5 };
            Trainer t7 = new Trainer() { FirstName = "Brandon", LastName = "Roth", Salary = 35000.00m, HireDate = new DateTime(2018, 03, 04), isAvailable = true };
            t7.Subjects = new List<Subject>() { s2, s6 };
            Trainer t8 = new Trainer() { FirstName = "Paul", LastName = "Burgees", Salary = 35500.50m, HireDate = new DateTime(2019, 02, 09), isAvailable = true };
            t8.Subjects = new List<Subject>() { s1, s4 };

            //==========Upsert Tables==========)
            context.Subjects.AddOrUpdate(x => x.Title, s1, s2, s3, s4, s5, s6);
            context.Trainers.AddOrUpdate(x => new { x.FirstName, x.LastName }, t1, t2, t3, t4, t5, t6, t7, t8);
            context.SaveChanges();
        }
    }
}
