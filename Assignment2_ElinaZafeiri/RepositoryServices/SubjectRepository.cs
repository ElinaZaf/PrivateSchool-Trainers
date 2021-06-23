using Assignment2_ElinaZafeiri.DAL;
using Assignment2_ElinaZafeiri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2_ElinaZafeiri.RepositoryServices
{
    public class SubjectRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Subject> GetAll()
        {
            return db.Subjects.ToList();
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