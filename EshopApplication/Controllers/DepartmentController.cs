using Eshop.Models.ViewModel;
using EshopApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EshopApplication.Controllers
{
    public class DepartmentController : Controller
    {

        private IDepartmentService departmentServices;

        public DepartmentController (IDepartmentService _departmentservices)
        {
            this.departmentServices = _departmentservices;
        }


        // GET: DepartmentController
        public async Task<IActionResult> Index()
        {
            var model=await departmentServices.GetAll();

            return View(model);
        }

        // GET: DepartmentController/Details/5
        public async  Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            ViewModelDepartment model = await departmentServices.Get(id);
            return View(model);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ViewModelDepartment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await departmentServices.Add(model);
                    return RedirectToAction(nameof(Index));

                }
                return View();

            }
            catch
            {
                throw new Exception("something went to wrong !");
            }
            return View();
        }

        // GET: DepartmentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewModelDepartment department = new ViewModelDepartment();
            if(id == 0)
            {
                return View(department);
            }
            department=await departmentServices.Get(id);
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ViewModelDepartment collection)
        {
            try
            {
                if(id == 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid) { 
                    await departmentServices.Update(collection);
                    return RedirectToAction(nameof(Index));
                }
               
            }
            catch
            {
                throw new InvalidOperationException();
            }
            return View();
        }



        // GET: DepartmentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var department = await departmentServices.Get(id);
                return View(department);
            }
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ViewModelDepartment model)
        {
            try
            {
                await departmentServices.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                
            }
            return View();
        }
    }
}
