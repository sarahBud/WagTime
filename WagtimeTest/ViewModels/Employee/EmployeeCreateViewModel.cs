using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WagtimeTest.Data;

namespace WagtimeTest.ViewModels.Employee
{
    public class EmployeeCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ZipCode { get; set; }

        public EmployeeCreateViewModel()
        {

        }
        public EmployeeCreateViewModel(ApplicationDbContext context) { }

        public void Persist(ApplicationDbContext context)
        {
            Models.Employee employee = new Models.Employee
            {
                Name = this.Name,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,

            };
            context.Employees.Add(employee);
            context.SaveChanges();
        }


    }
}
