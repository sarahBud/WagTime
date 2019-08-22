using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WagtimeTest.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DogName { get; set; }
        public string DogBreed { get; set; }
        public string Description { get; set; }
    }
}
