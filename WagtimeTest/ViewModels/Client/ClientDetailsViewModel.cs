using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WagtimeTest.Data;

namespace WagtimeTest.ViewModels.Client
{
    public class ClientDetailsViewModel
    {
        private ApplicationDbContext context;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DogName { get; set; }
        public string DogBreed { get; set; }
        public string DogDescription { get; set; }


        public static ClientDetailsViewModel GetClientDetailsViewModel(ApplicationDbContext context, int clientId)
        {
            ClientDetailsViewModel clientDetailsViewModel = new ClientDetailsViewModel();

            Models.Client client = context.Clients
               .FirstOrDefault(l => l.Id == clientId);

            return new ClientDetailsViewModel()
            {
                Name = client.Name,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Address = client.Address,
                Id = client.Id,
                DogName = client.DogName,
                DogBreed = client.DogBreed,
                DogDescription = client.DogDescription
            };
        }
    }
}
