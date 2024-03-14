using Burger.DATA.Concrete;
using Burger.SERVICE.Services.HamburgerService;
using Burger.WEBUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Area("Admin")]
    public class CrudBurgerController : Controller
    {
        private readonly IHamburgerSERVICE hamburgerService;

        public CrudBurgerController(IHamburgerSERVICE hamburgerService)
        {
            this.hamburgerService = hamburgerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await hamburgerService.GetAllAsync();
            ViewBag.data = "Burger";
            ViewBag.controller = "CrudBurger";
            if (result.Count > 0)
            {
                return View(result);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateHamburgerVM vm)
        {
            Hamburger hamburger = new Hamburger() { Name = vm.Name, Price = vm.Price, Description = vm.Description };

            hamburgerService.Add(hamburger);
            return RedirectToAction("Index", "CrudBurger");

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await hamburgerService.GetByIdAsync(id);
            CreateUpdateHamburgerVM vm = new CreateUpdateHamburgerVM() { Id = id, Name = result.Name, Description = result.Description, Price=result.Price };
            ViewBag.Title = "Update";
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateUpdateHamburgerVM vm)
        {

            Hamburger hamburger = await hamburgerService.GetByIdAsync(vm.Id);
            hamburger.Name = vm.Name;
            hamburger.Price = vm.Price;
            hamburger.Description = vm.Description;
            hamburgerService.Update(hamburger);
            return RedirectToAction("Index","CrudBurger");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Hamburger hamburger = await hamburgerService.GetByIdAsync(id);
            hamburgerService.Delete(hamburger);
            return RedirectToAction("Index", "CrudBurger");
        }



    }
}
