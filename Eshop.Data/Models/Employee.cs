using System.ComponentModel.DataAnnotations;

namespace Eshop.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }


        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }


        public DateTime? CreatedDate { get; set; }

        public int? DepartmentId{ get; set; }
        public Department? Department { get; set; }
    }
}
