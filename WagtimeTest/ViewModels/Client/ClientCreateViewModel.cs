using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WagtimeTest.Data;

namespace WagtimeTest.ViewModels.Client
{
    public class ClientCreateViewModel
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

        public string DogName { get; set; }
        public string DogBreed { get; set; }
        public string DogDescription { get; set; }
        public IFormFile Photo { get; set; }


        public ClientCreateViewModel()
        {

        }
        public ClientCreateViewModel(ApplicationDbContext context) { }

        public void Persist(ApplicationDbContext context)
        {
            Models.Client client = new Models.Client
            {
                Name = this.Name,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,
                DogName = this.DogName,
                DogBreed = this.DogBreed,
                DogDescription = this.DogDescription

            };
            context.Clients.Add(client);
            context.SaveChanges();
        }
    }
}
