using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2_ElinaZafeiri.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Display(Name = "Subject Name")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(25, ErrorMessage = "The length of this field must be maximum 25 characters.")]
        [MinLength(2, ErrorMessage = "The length of this field must be minimum 2 characters.")]
        public string Title { get; set; }


        // Navigation Properties
        public virtual ICollection<Trainer> Trainers { get; set; }

    }
}