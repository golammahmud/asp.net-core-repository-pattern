using System.ComponentModel.DataAnnotations;

namespace EshopApplication.Models.CustomValidation
{
    public class CustomJoiningDate: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
            //return base.IsValid(value);
        }
    }
}
