using Eshop.Data;
using Eshop.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eshop.Models.ViewModel;

namespace EshopApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController1 : ControllerBase
    {

        private IEmployeeRepository employeeRepository;
        ApplicationDbContext context;

        public EmployeeController1(IEmployeeRepository employeeRepository, ApplicationDbContext _context)
        {
            this.employeeRepository = employeeRepository;
            this.context = _context;
        }


        // GET: EmployeeController

        [HttpGet]
        public IEnumerable<ViewModelEmployee> Gets()
        {
            var model = employeeRepository.GetAllEmployees().Select(x => new ViewModelEmployee
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                CreatedDate = x.CreatedDate,
                Departments=new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>() { 
                    new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(){
                        Text=x.Department.Name,
                        Value=x.Department.ID+""
                }}.ToList()

            });

            return model;
            
        }

        // GET: EmployeeController/Details/5
        [HttpGet]
        public ViewModelEmployee Get(int id)
        {
            ViewModelEmployee model=new ViewModelEmployee();

            Employee employee = employeeRepository.GetEmployee(id);
            {
                model.Id = employee.Id;
                model.Name = employee.Name;
                model.Email = employee.Email;
                model.Phone = employee.Phone;
                model.Address = employee.Address;
                model.DepartmentId = employee.DepartmentId;
                model.CreatedDate = employee.CreatedDate;
            }            

            return model;
        }

        [HttpPost]
        public ViewModelEmployee Add(ViewModelEmployee model)
        {
            Employee employee = new Employee();

            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Phone = model.Phone;
                employee.Address = model.Address;
                employee.DepartmentId = (int)model.DepartmentId;
                employee.CreatedDate = model.CreatedDate;

            }
            employeeRepository.CreateEmployee(employee);

            return model;
        }

        // GET: EmployeeController/Edit/5

        [HttpPut]
        public ActionResult<bool> Update(ViewModelEmployee model)
        {
            employeeRepository.UpdateEmployee(new Employee
            {
                Id = (int)model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                DepartmentId = (int)model.DepartmentId,
                CreatedDate = model.CreatedDate,

            });

            return Ok(true);
        }

        [HttpDelete]
        public ActionResult<bool> Delete(int id)
        {
            employeeRepository.DeleteEmployee(id);

            return Ok(true);
        }
    }
}
