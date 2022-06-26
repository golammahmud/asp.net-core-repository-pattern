using Microsoft.AspNetCore.Mvc;
using Eshop.Data;
using Eshop.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eshop.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EshopApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository employeeRepository;
        ApplicationDbContext context;

        public EmployeeController(IEmployeeRepository employeeRepository, ApplicationDbContext _context)
        {
            this.employeeRepository = employeeRepository;
            this.context = _context;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<ViewModelEmployee> Get()
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
                Departments = new List<SelectListItem>() {
                    new SelectListItem(){
                        Text=x.Department?.Name,
                        Value=x.Department?.ID+""
                }}.ToList()

            });

            return model;

           // return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<ViewModelEmployee> Get(int id)
        {
            ViewModelEmployee model = new ViewModelEmployee();

            Employee employee = employeeRepository.GetEmployee(id);
            if (employee != null)
            {
                model.Id = employee.Id;
                model.Name = employee.Name;
                model.Email = employee.Email;
                model.Phone = employee.Phone;
                model.Address = employee.Address;
                model.DepartmentId = employee.DepartmentId;
                model.CreatedDate = employee.CreatedDate;
                model.Departments = new List<SelectListItem>() {
                    new SelectListItem(){
                        Text=employee.Department?.Name,
                        Value=employee.Department?.ID+""
                    }
                };
            }


            return Ok(model);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<ViewModelEmployee> Post([FromBody] ViewModelEmployee model)
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

            return  Ok(model);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult<ViewModelEmployee> Put(int id, [FromBody] ViewModelEmployee model)
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

            return Ok(model);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            employeeRepository.DeleteEmployee(id);

            return Ok(true);
        }
    }
}
