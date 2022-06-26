using Eshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Interface
{
    public interface IDepartmentRepository
    {
        
        Department GetDepartment(int id);

        IEnumerable<Department> GetAllDepartment();
        //Employee GetEmployeeById(int id);

        void CreateDepartment(Department department);

        void DeleteDepartment(int id);

        void UpdateDepartment(Department department);
    }
}
