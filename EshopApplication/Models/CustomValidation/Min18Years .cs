using EshopApplication.Models.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace EshopApplication.Models.CustomValidation
{
    public class Min18Years: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var employee = (ViewModelEmployee)validationContext.ObjectInstance;
            if (employee.CreatedDate == null)
            {
                return new ValidationResult("Date of Birth is required.");
            }
            var age = DateTime.Today.Year - employee.CreatedDate?.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Student should be at least 18 years old.");
        }
    }
}
