using Burger.DATA.Concrete;
using Burger.SERVICE.Services.ByProductService;
using Burger.SERVICE.Services.ExtraService;
using Burger.SERVICE.Services.MenuService;
using Burger.WEBUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Area("Admin")]
    public class CrudMenuController : Controller
    {
        private readonly IMenuSERVICE menuSERVICE;

        public CrudMenuController(IMenuSERVICE menuSERVICE)
        {
            this.menuSERVICE = menuSERVICE;
        }

        public async Task<IActionResult> Index()
        {
            var result = await menuSERVICE.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.Title = "Create";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateMenuVM vm)
        {
            Menu menu = new Menu() { Name = vm.Name, Price = vm.Price, Description = vm.Description };
            menuSERVICE.Add(menu);
            return RedirectToAction("Index", "CrudMenu");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await menuSERVICE.GetByIdAsync(id);
            CreateUpdateMenuVM vm = new CreateUpdateMenuVM() { Id = id, Name = result.Name, Description = result.Description, Price = result.Price };
            ViewBag.Title = "Update";
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateUpdateMenuVM vm)
        {
            Menu menu = await menuSERVICE.GetByIdAsync(vm.Id);
            menu.Name = vm.Name;
            menu.Price = vm.Price;
            menu.Description = vm.Description;
            menuSERVICE.Update(menu);
            return RedirectToAction("Index", "CrudMenu");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Menu menu = await menuSERVICE.GetByIdAsync(id);
            menuSERVICE.Delete(menu);
            return RedirectToAction("Index", "CrudMenu");
        }
    }
}
