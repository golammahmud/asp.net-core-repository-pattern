using Eshop.Data.Interface;
using Eshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private ApplicationDbContext  _appContext;

        public DepartmentRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return _appContext.Department.ToList();// as IEnumerable<Department>;
        }

        public Department GetDepartment(int id)
        {
            return _appContext.Department.FirstOrDefault(x=>x.ID == id);

        }

        public void CreateDepartment(Department employee)
        {
            try
            {
                _appContext.Department.Add(employee);
               _appContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void UpdateDepartment(Department employee)
        {
            _appContext.Department.Update(employee);
            _appContext.SaveChanges(true);
        }

        public void DeleteDepartment(int id)
        {
            Department department = _appContext.Department.FirstOrDefault(x=>x.ID == id);
            _appContext.Department.Remove(department);
            _appContext.SaveChanges();
        }

        
    }
}
