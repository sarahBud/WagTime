using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WagtimeTest.Data;

namespace WagtimeTest.ViewModels.Employee
{
    public class EmployeeEditViewModel
    {
        public EmployeeEditViewModel() { }

        private ApplicationDbContext context;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }

        public EmployeeEditViewModel(int id, ApplicationDbContext context)
        {

            Models.Employee employee = context.Employees.
                Single(l => l.Id == id);

            Name = employee.Name;
            Email = employee.Email;
            PhoneNumber = employee.PhoneNumber;
            Address = employee.Address;
            ZipCode = employee.ZipCode;

        }

        public void Persist(int id, ApplicationDbContext context)
        {
            Models.Employee employee = new Models.Employee()
            {
                Id = id,
                Name = this.Name,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,
                ZipCode = this.ZipCode

            };
            context.Update(employee);

            context.SaveChanges();

        }
    }
}
