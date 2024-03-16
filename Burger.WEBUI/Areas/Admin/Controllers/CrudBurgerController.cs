using Burger.DATA.Concrete;
using Burger.REPO.Contexts;
using Burger.SERVICE.Services.ExtraService;
using Burger.SERVICE.Services.HamburgerExtraService;
using Burger.SERVICE.Services.HamburgerService;
using Burger.WEBUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CrudBurgerController(IHamburgerSERVICE hamburgerService, IExtraSERVICE extraService, IHamburgerExtraSERVICE hamburgerExtraService, BurgerDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.hamburgerService = hamburgerService;
            this.extraService = extraService;
            this.hamburgerExtraService = hamburgerExtraService;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Create(CreateUpdateHamburgerVM vm, List<int> selectedIds, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                vm.Photo = HelperClass.Helper.AddPhoto(file, _webHostEnvironment);

                Hamburger hamburger = new Hamburger() { Name = vm.Name, Price = vm.Price, Description = vm.Description, Photo = vm.Photo };
                hamburgerService.Add(hamburger);

                hamburger.HamburgerExtras = new List<HamburgerExtra>();

                foreach (var item in selectedIds)
                {
                    hamburger.HamburgerExtras.Add(new HamburgerExtra() { ExtraId = item, HamburgerId = hamburger.Id });
                }

                hamburgerExtraService.Create(hamburger.HamburgerExtras);

                return RedirectToAction("Index","CrudBurger");
            }
            else
            {
                Hamburger hamburger = new Hamburger() { Name = vm.Name, Price = vm.Price, Description = vm.Description};
                hamburgerService.Add(hamburger);

                hamburger.HamburgerExtras = new List<HamburgerExtra>();

                foreach (var item in selectedIds)
                {
                    hamburger.HamburgerExtras.Add(new HamburgerExtra() { ExtraId = item, HamburgerId = hamburger.Id });
                }

                hamburgerExtraService.Create(hamburger.HamburgerExtras);

                return RedirectToAction("Index", "CrudBurger");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await hamburgerService.GetByIdAsync(id);
            var extra = await extraService.GetAllAsync();

            result.HamburgerExtras = (List<HamburgerExtra>)hamburgerExtraService.GetByBurgerId(id);

            CreateUpdateHamburgerVM vm = new CreateUpdateHamburgerVM() { Id = id, Name = result.Name, Description = result.Description, Price = result.Price, HamburgerExtras = (List<HamburgerExtra>)result.HamburgerExtras, Extras = extra, Photo=result.Photo};

            ViewBag.Title = "Update";
            ViewBag.baslik = "Güncelle";

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateUpdateHamburgerVM vm, List<int> selectedIds, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                Hamburger hamburger = await hamburgerService.GetByIdAsync(vm.Id);
                hamburger.Name = vm.Name;
                hamburger.Price = vm.Price;
                hamburger.Description = vm.Description;
                hamburger.Photo = HelperClass.Helper.AddPhoto(file, _webHostEnvironment);

                hamburgerService.Update(hamburger);

                var result = hamburgerExtraService.GetByBurgerId(vm.Id);

                hamburgerExtraService.Delete(result);

                hamburger.HamburgerExtras = new List<HamburgerExtra>();

                foreach (var item in selectedIds)
                {
                    hamburger.HamburgerExtras.Add(new HamburgerExtra() { ExtraId = item, HamburgerId = hamburger.Id });
                }

                hamburgerExtraService.Create(hamburger.HamburgerExtras);

                return RedirectToAction("Index", "CrudBurger");
            }
            else
            {
                Hamburger hamburger = await hamburgerService.GetByIdAsync(vm.Id);
                hamburger.Name = vm.Name;
                hamburger.Price = vm.Price;
                hamburger.Description = vm.Description;
                hamburger.Photo = vm.Photo;

                hamburgerService.Update(hamburger);

                var result = hamburgerExtraService.GetByBurgerId(vm.Id);

                hamburgerExtraService.Delete(result);

                hamburger.HamburgerExtras = new List<HamburgerExtra>();

                foreach (var item in selectedIds)
                {
                    hamburger.HamburgerExtras.Add(new HamburgerExtra() { ExtraId = item, HamburgerId = hamburger.Id });
                }

                hamburgerExtraService.Create(hamburger.HamburgerExtras);

                return RedirectToAction("Index", "CrudBurger");
            }
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
