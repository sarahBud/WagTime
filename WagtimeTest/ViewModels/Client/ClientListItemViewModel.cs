using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WagtimeTest.Data;

namespace WagtimeTest.ViewModels.Client
{
    public class ClientListItemViewModel
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

        public static List<ClientListItemViewModel> GetClientListItemViewModel(ApplicationDbContext context)
        {


            List<Models.Client> clients = context.Clients
                .ToList();


            List<ClientListItemViewModel> viewModelClients = new List<ClientListItemViewModel>();
            foreach (Models.Client client in clients)
            {
                ClientListItemViewModel viewModel = new ClientListItemViewModel();
                viewModel.Id = client.Id;
                viewModel.Name = client.Name;
                viewModel.Email = client.Email;
                viewModel.PhoneNumber = client.PhoneNumber;
                viewModel.Address = client.Address;
                viewModel.DogName = client.DogName;
                viewModel.DogBreed = client.DogBreed;
                viewModel.DogDescription = client.DogDescription;

                viewModelClients.Add(viewModel);

            }
            return viewModelClients;


        }
    }
}
