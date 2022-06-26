using Eshop.Data;
using Eshop.Data.Models;
using Eshop.Models.ViewModel;
using EshopApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EshopApplication.Controllers
{
    public class EmployeeController : Controller
    {

        private IEmployeeService EmployeeService;
        ApplicationDbContext context;

        public EmployeeController(IEmployeeService _employeeService, ApplicationDbContext _context)
        {
            this.EmployeeService = _employeeService;
            this.context = _context;
        }

        // GET: EmployeeController

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model =await EmployeeService.GetAll();
            return View(model);
            
        }

        // GET: EmployeeController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            ViewModelEmployee model= await EmployeeService.Get(id);

            return View(model);

        }

        // GET: EmployeeController/Create
      
        public async Task<IActionResult> Create()
        {
            var model = new ViewModelEmployee();

            model.Departments = context.Department.ToList().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = x.Name,
                Value = x.ID + ""
            }).ToList();

            return View(model);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ViewModelEmployee model)
        {
            try {

               if (ModelState.IsValid)
                {
                    await EmployeeService.Add(model);

                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            model.Departments = context.Department.ToList().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = x.Name,
                Value = x.ID + ""
            }).ToList();

            return View(model);
        }

        // GET: EmployeeController/Edit/5

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ViewModelEmployee model = new ViewModelEmployee();
            if (id == 0)
            {
                return View(model);
            }

            model= await EmployeeService.Get(id);


            model.Departments = context.Department.ToList().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = x.Name,
                Value = x.ID + ""
            }).ToList();

            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ViewModelEmployee model)
        {
            try
            {
                if(id == 0)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    await EmployeeService.Update(model);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                
            }

            return View();
        }

        // GET: EmployeeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id != 0)
            {
                ViewModelEmployee model = await EmployeeService.Get(id);

                return View(model);

            }
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ViewModelEmployee employee)
        {
            try
            {
                if (await EmployeeService.Remove(id))
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
               
            }

            return View();
        }
    }
}
