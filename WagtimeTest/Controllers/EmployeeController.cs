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


        //public IActionResult Details(int id)
        //{

        //    EmployeeDetailsViewModel employeeDetailsViewModel = EmployeeDetailsViewModel.GetEmployeeDetailsViewModel(context, id);
        //    return View(employeeDetailsViewModel);
        //}

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    return View(model: new LocationEditViewModel(id, context));
        //}

        //[HttpPost]
        //public IActionResult Edit(LocationEditViewModel locationEditViewModel, int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(new LocationEditViewModel());
        //    }
        //    locationEditViewModel.Persist(id, context);
        //    return RedirectToAction(actionName: nameof(Index));
        //}

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    return View(new EmployeeEditViewModel(id, context));
        //}

        //[HttpPost]
        //public IActionResult Edit(int id, EmployeeEditViewModel location)
        //{
        //    if (!ModelState.IsValid)
        //    {

        //        return View(location);
        //    }

        //    location.Persist(id, context);
        //    return RedirectToAction(actionName: nameof(Index));
        //}
    }
}