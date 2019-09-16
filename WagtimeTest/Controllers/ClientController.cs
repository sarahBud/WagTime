using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WagtimeTest.Data;
using WagtimeTest.ViewModels.Client;

namespace WagtimeTest.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext context;

        public ClientController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<ClientListItemViewModel> viewModelClients = ClientListItemViewModel.GetClientListItemViewModel(context);
            return View(viewModelClients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ClientCreateViewModel model = new ClientCreateViewModel(context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ClientCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            model.Persist(context);
            return RedirectToAction(actionName: nameof(Index));
        }


        public IActionResult Details(int id)
        {

            ClientDetailsViewModel clientDetailsViewModel = ClientDetailsViewModel.GetClientDetailsViewModel(context, id);
            return View(clientDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(new ClientEditViewModel(id, context));
        }

        [HttpPost]
        public IActionResult Edit(int id, ClientEditViewModel client)
        {
            if (!ModelState.IsValid)
            {

                return View(client);
            }

            client.Persist(id, context);
            return RedirectToAction(actionName: nameof(Index));
        }
        

        public async Task<IActionResult> Delete(int? id)
        {
            var client = await context.Clients.FindAsync(id);
            context.Clients.Remove(client);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}