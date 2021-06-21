using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2_ElinaZafeiri.DAL;
using Assignment2_ElinaZafeiri.Models;

namespace Assignment2_ElinaZafeiri.Controllers
{
    public class SubjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subject
        public ActionResult Index()
        {
            return View(db.Subjects.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
