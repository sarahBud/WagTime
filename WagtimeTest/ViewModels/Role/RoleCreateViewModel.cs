using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WagtimeTest.ViewModels.Role
{
    public class RoleCreateViewModel
    {
        [Required]
        public string RoleName { get; set; }

        public RoleCreateViewModel() { }
    }
}
