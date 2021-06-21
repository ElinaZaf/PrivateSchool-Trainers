using Assignment2_ElinaZafeiri.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2_ElinaZafeiri.DAL
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("ONOMA")
        {

        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}