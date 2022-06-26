using Eshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data
{
    public interface IEmployeeRepository
    {
        void CreateEmployee(Employee employee);
        Employee GetEmployee(int id);     

        IEnumerable<Employee> GetAllEmployees();
        //Employee GetEmployeeById(int id);

        void DeleteEmployee(int id );

        void UpdateEmployee(Employee employee);

        
    }
}
