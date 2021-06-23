using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2_ElinaZafeiri.DAL;
using Assignment2_ElinaZafeiri.RepositoryServices;

namespace Assignment2_ElinaZafeiri.Models.ViewModels
{
    public class TrainerCreateViewModel
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        SubjectRepository SubjectRepository = new SubjectRepository();

        public IEnumerable<SelectListItem> SelectedSubjectIds
        {
            get
            {
                return SubjectRepository.GetAll().Select(x => new SelectListItem()
                {
                    Value = x.SubjectId.ToString(),
                    Text = x.Title
                });
            }
        }

        public Trainer Trainer { get; set; }
    }
}