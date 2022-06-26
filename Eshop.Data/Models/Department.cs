using System.ComponentModel.DataAnnotations;

namespace Eshop.Data.Models { 
    public class Department
    {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public ICollection<Employee>? Employees { get; set; }

    }
}
