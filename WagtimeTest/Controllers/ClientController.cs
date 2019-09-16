using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WagtimeTest.Data;
using WagtimeTest.Models;
using WagtimeTest.ViewModels.Client;

namespace WagtimeTest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClientController : Controller
    {
        private ApplicationDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;

        public ClientController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            this.context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            List<ClientListItemViewModel> viewModelClients = ClientListItemViewModel.GetClientListItemViewModel(context);
            return View(viewModelClients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Client newClient = new Client
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    DogName = model.DogName,
                    DogBreed = model.DogBreed,
                    DogDescription = model.DogDescription,
                    PhotoPath = uniqueFileName
                };

                model.Persist(context);
                return RedirectToAction(actionName: nameof(Index));
            }
            return View();
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