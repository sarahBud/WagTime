using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WagtimeTest.Data;
using WagtimeTest.ViewModels.Employee;

namespace WagtimeTest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<EmployeeListItemViewModel> viewModelEmployees = EmployeeListItemViewModel.GetEmployeeListItemViewModel(context);
            return View(viewModelEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EmployeeCreateViewModel model = new EmployeeCreateViewModel(context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            model.Persist(context);
            return RedirectToAction(actionName: nameof(Index));
        }


        public IActionResult Details(int id)
        {

            EmployeeDetailsViewModel employeeDetailsViewModel = EmployeeDetailsViewModel.GetEmployeeDetailsViewModel(context, id);
            return View(employeeDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(new EmployeeEditViewModel(id, context));
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeEditViewModel employee)
        {
            if (!ModelState.IsValid)
            {

                return View(employee);
            }

            employee.Persist(id, context);
            return RedirectToAction(actionName: nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await context.Employees.FindAsync(id);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}