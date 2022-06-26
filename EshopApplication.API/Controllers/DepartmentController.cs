using Eshop.Data.Interface;
using Eshop.Data.Models;
using Eshop.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EshopApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {


        private IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository _departmentRepository)
        {
            this.departmentRepository = _departmentRepository;
        }





        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<ViewModelDepartment> Get()
        {

            var model = departmentRepository.GetAllDepartment().Select(x => new ViewModelDepartment
            {
                ID = x.ID,
                Name = x.Name,
                CreatedDate = (DateTime)x.CreatedDate
            });

            return model;
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public ActionResult <ViewModelDepartment> Get(int id)
        {
            ViewModelDepartment model = new ViewModelDepartment();

            Department department = departmentRepository.GetDepartment(id);
            if (department != null)
            {
                {
                    model.ID = department.ID;
                    model.Name = department.Name;
                    model.CreatedDate = (DateTime)department.CreatedDate;
                }
            }
            return Ok(model);
        }




        // POST api/<DepartmentController>
        [HttpPost]
        public ActionResult<ViewModelDepartment> Post([FromBody] ViewModelDepartment model)
        {
            departmentRepository.CreateDepartment(new Department
            {
                ID=model.ID,
                CreatedDate = model.CreatedDate,
                Name = model.Name,


            });

            return Ok(model);

        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public ActionResult<ViewModelDepartment> Put(int id, [FromBody] ViewModelDepartment model)
        {
            var department = departmentRepository.GetDepartment(id);
            if (department != null)
            {
                departmentRepository.UpdateDepartment(new Department
                {
                    ID = model.ID,
                    Name = model.Name,
                    CreatedDate=model.CreatedDate,
                });
            }
            return Ok(model);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            departmentRepository.DeleteDepartment(id);

            return Ok(true);
        }
    }
}
