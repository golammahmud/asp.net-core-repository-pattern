using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eshop.Data;
using Eshop.Data.Models;
using Microsoft.EntityFrameworkCore;



namespace Eshop.Data
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private  ApplicationDbContext _dbContext;

       public EmployeeRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employee.Include("Department").ToList();// as IEnumerable<Employee>;
        }

        public Employee GetEmployee(int id)
        {
            var employee = _dbContext.Employee.Include("Department").Where(x => x.Id == id).FirstOrDefault();
            return employee;
        }

        //public Employee GetEmployeeById(int id)
        //{
        //    return _dbContext.Employee.FirstOrDefault(x => x.Id == id);
        //}

        public void CreateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employee.Add(employee);
                _dbContext.SaveChanges();

              
            } 
            catch (Exception e)
            {
                throw new ArgumentNullException(nameof(employee));
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                //var employee = _dbContext.Employee.Find(id);

                //_dbContext.Employee.Remove(employee);

                //_dbContext.SaveChanges();

                Employee employee = GetEmployee(id);
                if (employee != null)
                {
                    _dbContext.Employee.Remove(employee);
                    _dbContext.SaveChanges();
                }
                

            }
            catch (Exception ex)
            {
                throw new Exception("record not found");
            }

        }

        public void UpdateEmployee(Employee employee)
        {
            _dbContext.Update(employee);
            _dbContext.SaveChanges();
        }


    }
}
