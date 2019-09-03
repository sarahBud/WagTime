using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WagtimeTest.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }


        //public IList<Review> Reviews { get; set; }
        //public IList<LocationCategory> LocationCategories { get; set; }
    }
}
