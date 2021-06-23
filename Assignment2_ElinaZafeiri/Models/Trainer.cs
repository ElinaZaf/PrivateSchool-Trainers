using Assignment2_ElinaZafeiri.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment2_ElinaZafeiri.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^[A-Za-z]+([-][A-Za-z]*)*$", ErrorMessage = "First Name must contain only letters. For multiple names, please, use  -  separator (no spaces allowed).")]
        [MaxLength(25, ErrorMessage = "The length of this field must be maximum 25 characters.")]
        [MinLength(2, ErrorMessage = "The length of this field must be minimum 2 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^[A-Za-z]+([\\'-][A-Za-z]*)*$", ErrorMessage = "Last Name must contain only letters. For multiple names, please, use  -  or  '  separator (no spaces allowed).")]
        [MaxLength(25, ErrorMessage = "The length of this field must be maximum 25 characters.")]
        [MinLength(2, ErrorMessage = "The length of this field must be minimum 2 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Annual Salary")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Currency)]
        [CustomValidation(typeof(MyValidationMethods), "ValidateGreaterOrEqualToZero")]
        public decimal Salary { get; set; }

        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [Display(Name = "Available for Work")]
        public bool isAvailable { get; set; }


        // Navigation Properties
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}