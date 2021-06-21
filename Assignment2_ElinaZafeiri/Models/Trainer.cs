using Assignment2_ElinaZafeiri.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2_ElinaZafeiri.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(25, ErrorMessage = "The length of this field must be maximum 25 characters.")]
        [MinLength(2, ErrorMessage = "The length of this field must be minimum 2 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(25, ErrorMessage = "The length of this field must be maximum 25 characters.")]
        [MinLength(2, ErrorMessage = "The length of this field must be minimum 2 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Annual Salary")]
        [CustomValidation(typeof(MyValidationMethods), "ValidateGreaterOrEqualToZero")]
        public decimal Salary { get; set; }

        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Available for Work")]
        public bool isAvailable { get; set; }


        // Navigation Properties
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}