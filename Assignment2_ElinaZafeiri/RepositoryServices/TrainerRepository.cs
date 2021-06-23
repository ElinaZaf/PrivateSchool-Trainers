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

        public void Create(Trainer trainer, IEnumerable<int> SelectedSubjectIds)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).Collection("Subjects").Load();
            trainer.Subjects.Clear();
            db.SaveChanges();

            if (!(SelectedSubjectIds is null))
            {
                foreach (var id in SelectedSubjectIds)
                {
                    Subject subject = db.Subjects.Find(id);
                    if (subject != null)
                    {
                        trainer.Subjects.Add(subject);
                    }
                }
            }

            db.Entry(trainer).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Trainer trainer, IEnumerable<int> SelectedSubjectIds)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).Collection("Subjects").Load();
            trainer.Subjects.Clear();
            db.SaveChanges();

            if (!(SelectedSubjectIds is null) )
            {
                foreach (var id in SelectedSubjectIds)
                {
                    Subject subject = db.Subjects.Find(id);
                    if (subject != null)
                    {
                        trainer.Subjects.Add(subject);
                    }
                }
            }

            db.Entry(trainer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Attach(Trainer trainer)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).Collection("Subjects").Load();
        }

        public void Delete(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            trainer.Subjects.Clear();
            db.Entry(trainer).State = EntityState.Deleted;
            db.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}