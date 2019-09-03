using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WagtimeTest.Data;

namespace WagtimeTest.ViewModels.Employee
{
    public class EmployeeListItemViewModel
    {
        public static List<EmployeeListItemViewModel> GetEmployeeListItemViewModel(ApplicationDbContext context)
        {
            List<Models.Employee> employees = context.Employees
                .ToList();


            List<EmployeeListItemViewModel> viewModelEmployees = new List<EmployeeListItemViewModel>();
            foreach (Models.Employee employee in employees)
            {
                EmployeeListItemViewModel viewModel = new EmployeeListItemViewModel();
                viewModel.Id = employee.Id;
                viewModel.Name = employee.Name;
                viewModel.Email = employee.Email;
                viewModel.PhoneNumber = employee.PhoneNumber;
                viewModel.Address = employee.Address;

                viewModelEmployees.Add(viewModel);

            }
            return viewModelEmployees;


        }

        //private static string GetCategoryNames(Models.Location location, ApplicationDbContext context)
        //{
        //    //List<string> categoryNames = location.LocationCategories
        //    //    .Select(lc => lc.Category)
        //    //    .Select(c => c.CategoryName)
        //    //    .ToList();

        //    List<int> categoryIds = location.LocationCategories.Select(lc => lc.CategoryId).ToList();
        //    List<Category> categories = context.Categories.Where(c => categoryIds.Contains(c.Id)).ToList();
        //    categoryNames = categories.Select(c => c.CategoryName).ToList();

        //    return String.Join(", ", categoryNames);
        //}

        private ApplicationDbContext context;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }




    }
}

