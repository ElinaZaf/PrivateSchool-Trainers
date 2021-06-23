using Assignment2_ElinaZafeiri.DAL;
using Assignment2_ElinaZafeiri.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2_ElinaZafeiri.Models.ViewModels
{
    public class TrainerEditViewModel
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        SubjectRepository SubjectRepository = new SubjectRepository();

        public Trainer Trainer { get; set; }

        public IEnumerable<SelectListItem> SelectedSubjectIds
        {
            get
            {
                if (Trainer is null)
                {
                    return SubjectRepository.GetAll().Select(x => new SelectListItem()
                    {
                        Value = x.SubjectId.ToString(),
                        Text = x.Title
                    });
                }
                else
                {
                    var subjectIds = Trainer.Subjects.Select(x => x.SubjectId);
                    return SubjectRepository.GetAll().Select(x => new SelectListItem()
                    {
                        Value = x.SubjectId.ToString(),
                        Text = x.Title,
                        Selected = subjectIds.Any(y => y == x.SubjectId)
                    });
                }
            }
            
        }

        public TrainerEditViewModel(Trainer trainer)
        {
            Trainer = trainer;
        }


    }
}