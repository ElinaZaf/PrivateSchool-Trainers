using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2_ElinaZafeiri.CustomValidations
{
    public class MyValidationMethods
    {
        public static ValidationResult ValidateGreaterOrEqualToZero(decimal value, ValidationContext context)
        {
            bool isValid = true;
            if (value < 0)
            {
                isValid = false;
            }

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("This field must have value greater or equal to 0.", new List<string> { context.MemberName });
            }
        }
    }
}