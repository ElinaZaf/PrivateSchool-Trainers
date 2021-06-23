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
using Assignment2_ElinaZafeiri.Models.ViewModels;
using Assignment2_ElinaZafeiri.RepositoryServices;
using PagedList;

namespace Assignment2_ElinaZafeiri.Controllers
{
    public class TrainerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private TrainerRepository TrainerRepository = new TrainerRepository();

        // GET: Trainer
        public ActionResult Index(string searchBy, string search, int? page, string sortOrder)
        {
            var trainers = TrainerRepository.GetAll();

            //Filtering
            
            try
            {
                if (searchBy == "FirstName")
                {
                    trainers = trainers.Where(x => x.FirstName.ToUpper().Contains(search.ToUpper()) || search == null).ToList();
                }
                if (searchBy == "LastName")
                {
                    trainers = trainers.Where(x => x.LastName.ToUpper().Contains(search.ToUpper()) || search == null).ToList();
                }
                if (searchBy == "MinSalary")
                {
                    trainers = trainers.Where(x => x.Salary >= Convert.ToDecimal(search) || search == null).ToList();
                }
                if (searchBy == "MaxSalary")
                {
                    trainers = trainers.Where(x => x.Salary <= Convert.ToDecimal(search) || search == null).ToList();
                }
                if (searchBy == "HireDateYear")
                {
                    trainers = trainers.Where(x => x.HireDate.Year == Convert.ToInt32(search) || search == null).ToList();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Something went wrong!");
            }


            //Sorting
            ViewBag.FNSP = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : "";
            ViewBag.LNSP = sortOrder == "LastNameAsc" ? "LastNameDesc" : "LastNameAsc";
            ViewBag.SSP = sortOrder == "SalaryAsc" ? "SalaryDesc" : "SalaryAsc";
            ViewBag.HDSP = sortOrder == "HireDateAsc" ? "HireDateDesc" : "HireDateAsc";
            ViewBag.IASP = sortOrder == "IsAvailableAsc" ? "IsAvailableDesc" : "IsAvailableAsc";

            switch (sortOrder)
            {
                case "FirstNameDesc": trainers = trainers.OrderByDescending(x => x.FirstName).ToList(); break;
                case "LastNameAsc": trainers = trainers.OrderBy(x => x.LastName).ToList(); break;
                case "LastNameDesc": trainers = trainers.OrderByDescending(x => x.LastName).ToList(); break;
                case "SalaryAsc": trainers = trainers.OrderBy(x => x.Salary).ToList(); break;
                case "SalaryDesc": trainers = trainers.OrderByDescending(x => x.Salary).ToList(); break;
                case "HireDateAsc": trainers = trainers.OrderBy(x => x.HireDate).ToList(); break;
                case "HireDateDesc": trainers = trainers.OrderByDescending(x => x.HireDate).ToList(); break;
                case "IsAvailableAsc": trainers = trainers.OrderBy(x => x.isAvailable).ToList(); break;
                case "IsAvailableDesc": trainers = trainers.OrderByDescending(x => x.isAvailable).ToList(); break;
                default: trainers = trainers.OrderBy(x => x.FirstName).ToList(); break;
            }

            //Pagination
            int pageSize = 4;
            int pageNumber = page ?? 1;

            return View(trainers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = TrainerRepository.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            TrainerCreateViewModel vm = new TrainerCreateViewModel();
            return View(vm);
        }

        // POST: Trainer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerId,FirstName,LastName,Salary,HireDate,isAvailable")] Trainer trainer, IEnumerable<int> SelectedSubjectIds)
        {
            if (ModelState.IsValid)
            {
                TrainerRepository.Create(trainer, SelectedSubjectIds);
                return RedirectToAction("Index");
            }
            TrainerCreateViewModel vm = new TrainerCreateViewModel();
            return View(vm);
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = TrainerRepository.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            TrainerEditViewModel vm = new TrainerEditViewModel(trainer);
            return View(vm);
        }

        // POST: Trainer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerId,FirstName,LastName,Salary,HireDate,isAvailable")] Trainer trainer, IEnumerable<int> SelectedSubjectIds)
        {
            if (ModelState.IsValid)
            {
                TrainerRepository.Edit(trainer, SelectedSubjectIds);
                return RedirectToAction("Index");
            }
            TrainerRepository.Attach(trainer);
            TrainerEditViewModel vm = new TrainerEditViewModel(trainer);
            return View(vm);
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = TrainerRepository.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainerRepository.Delete(id);
            return RedirectToAction("Index");
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
