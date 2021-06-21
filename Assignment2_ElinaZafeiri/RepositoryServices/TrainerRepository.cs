using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Assignment2_ElinaZafeiri.DAL;
using Assignment2_ElinaZafeiri.Models;

namespace Assignment2_ElinaZafeiri.RepositoryServices
{
    public class TrainerRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Trainer> GetAll()
        {
            return db.Trainers.ToList();
        }

        public Trainer GetById(int? id)
        {
            return db.Trainers.Find(id);
        }



    }
}