using Burger.DATA.Concrete;
using Burger.REPO.Contexts;
using Burger.SERVICE.Services.ExtraService;
using Burger.SERVICE.Services.HamburgerExtraService;
using Burger.SERVICE.Services.HamburgerService;
using Burger.WEBUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Burger.WEBUI.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Area("Admin")]
    public class CrudBurgerController : Controller
    {
        private readonly IHamburgerSERVICE hamburgerService;
        private readonly IExtraSERVICE extraService;
        private readonly IHamburgerExtraSERVICE hamburgerExtraService;
        private readonly BurgerDbContext dbContext;

        public CrudBurgerController(IHamburgerSERVICE hamburgerService, IExtraSERVICE extraService, IHamburgerExtraSERVICE hamburgerExtraService, BurgerDbContext dbContext)
        {
            this.hamburgerService = hamburgerService;
            this.extraService = extraService;
            this.hamburgerExtraService = hamburgerExtraService;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await hamburgerService.GetAllAsync();
            var extras = await extraService.GetAllAsync();
            var extraHamburger = await hamburgerExtraService.GetAllAsync();
            ListHamburgerVM vm = new ListHamburgerVM();
            vm.Hamburgers = result;
            vm.Extras = extras;
            vm.HamburgerExtras = extraHamburger;
            
            ViewBag.data = "Burger";
            ViewBag.controller = "CrudBurger";
            if (result.Count > 0)
            {
                return View(vm);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateUpdateHamburgerVM vm = new CreateUpdateHamburgerVM();
            var result = await extraService.GetAllAsync();
            vm.Extras = result;
            ViewBag.Title = "Create";
            ViewBag.baslik = "Ekle";
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateHamburgerVM vm, List<int> selectedIds)
        {
            Hamburger hamburger = new Hamburger() { Name = vm.Name, Price = vm.Price, Description = vm.Description};

            hamburgerService.Add(hamburger);

            HamburgerExtra hamburgerExtra = new HamburgerExtra();

            hamburger.HamburgerExtras = new List<HamburgerExtra>();

            foreach (var item in selectedIds)
            {
                hamburger.HamburgerExtras.Add(new HamburgerExtra() { ExtraId = item ,HamburgerId=hamburger.Id });
            }

            hamburgerExtraService.Create(hamburger.HamburgerExtras);

            return RedirectToAction("Index", "CrudBurger");

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await hamburgerService.GetByIdAsync(id);
            var extra = await extraService.GetAllAsync();
            result.HamburgerExtras = (List<HamburgerExtra>)hamburgerExtraService.GetByBurgerId(id);
            CreateUpdateHamburgerVM vm = new CreateUpdateHamburgerVM() { Id = id, Name = result.Name, Description = result.Description, Price=result.Price, HamburgerExtras = (List<HamburgerExtra>)result.HamburgerExtras ,Extras = extra };

            ViewBag.Title = "Update";
            ViewBag.baslik = "Güncelle";
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateUpdateHamburgerVM vm, List<int> selectedIds) 
        {

            Hamburger hamburger = await hamburgerService.GetByIdAsync(vm.Id);
            hamburger.Name = vm.Name;
            hamburger.Price = vm.Price;
            hamburger.Description = vm.Description;

            hamburgerService.Update(hamburger);

            var result = hamburgerExtraService.GetByBurgerId(vm.Id);
            hamburgerExtraService.Delete(result);

            HamburgerExtra hamburgerExtra = new HamburgerExtra();

            hamburger.HamburgerExtras = new List<HamburgerExtra>();

            foreach (var item in selectedIds)
            {
                hamburger.HamburgerExtras.Add(new HamburgerExtra() { ExtraId = item, HamburgerId = hamburger.Id });
            }


            hamburgerExtraService.Create(hamburger.HamburgerExtras);


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
