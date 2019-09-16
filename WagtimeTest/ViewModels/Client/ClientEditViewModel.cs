using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WagtimeTest.Data;

namespace WagtimeTest.ViewModels.Client
{
    public class ClientEditViewModel
    {
        public ClientEditViewModel() { }

        private ApplicationDbContext context;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DogName { get; set; }
        public string DogBreed { get; set; }
        public string DogDescription { get; set; }

        public ClientEditViewModel(int id, ApplicationDbContext context)
        {

            Models.Client client = context.Clients.
                Single(l => l.Id == id);

            Name = client.Name;
            Email = client.Email;
            PhoneNumber = client.PhoneNumber;
            Address = client.Address;
            DogName = client.DogName;
            DogBreed = client.DogBreed;
            DogDescription = client.DogDescription;


        }

        public void Persist(int id, ApplicationDbContext context)
        {
            Models.Client client = new Models.Client()
            {
                Id = id,
                Name = this.Name,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,
                DogName = this.DogName,
                DogBreed = this.DogBreed,
                DogDescription = this.DogDescription
            };
            context.Update(client);

            context.SaveChanges();

        }
    }
}
