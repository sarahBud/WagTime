using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WagtimeTest.Data;

namespace WagtimeTest.ViewModels.Employee
{
    public class EmployeeDetailsViewModel
    {
        private ApplicationDbContext context;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

  

        public static EmployeeDetailsViewModel GetEmployeeDetailsViewModel(ApplicationDbContext context, int employeeId)
        {
            EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel();

            Models.Employee employee = context.Employees
               .FirstOrDefault(l => l.Id == employeeId);

            return new EmployeeDetailsViewModel()
            {
                Name = employee.Name,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                Id = employee.Id
            };
        }
    }
}
