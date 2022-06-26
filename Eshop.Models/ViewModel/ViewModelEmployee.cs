using Eshop.Models.CustomValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Models.ViewModel
{
    public class ViewModelEmployee
    {
        public ViewModelEmployee()
        {
            this.Departments = new List<SelectListItem>();
        }
        public int Id { get; set; }


       [Required(ErrorMessage ="Name field can not be blank")]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Name { get; set; }


        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string Phone { get; set; }

        public string Address { get; set; }


        [Required]
        public int? DepartmentId { get; set; }


        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        //[Min18Years]
        [CustomJoiningDate(ErrorMessage = "Admission Date must be less than or equal to Today's Date.")]
        public DateTime? CreatedDate { get; set; }

        public List<SelectListItem> Departments { get; set; }


    }
}
