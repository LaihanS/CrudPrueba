using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.IServices;
using SocialNetwork.Core.Application.ViewModels;
using SocialNetwork.Models;
using System.Diagnostics;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyService propertyService;

        public HomeController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await propertyService.GetAllByID());
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveProperty", await propertyService.GetByID(id));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SavePropertyViewModel prop)
        {
            await propertyService.UpdateAsync(prop, prop.id);
            return RedirectToRoute(new {controller="Home", action="Index" });
        }

        public async Task<IActionResult> Create()
        {
            return View("SaveProperty", new SavePropertyViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Create(SavePropertyViewModel prop)
        {
            await propertyService.CreateAsync(prop);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("DeleteProperty", await propertyService.GetByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SavePropertyViewModel prop)
        {
            await propertyService.DeleteAsync(prop);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }



    }
}