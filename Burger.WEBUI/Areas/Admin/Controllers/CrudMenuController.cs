using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.SERVICE.Services.ByProductService;
using Burger.SERVICE.Services.ExtraService;
using Burger.SERVICE.Services.HamburgerExtraService;
using Burger.SERVICE.Services.HamburgerService;
using Burger.SERVICE.Services.MenuByProductService;
using Burger.SERVICE.Services.MenuHamburgerService;
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
        private readonly IHamburgerSERVICE hamburgerSERVICE;
        private readonly IByProductSERVICE byProductService;
        private readonly IMenuByProductSERVICE menuByProductService;
        private readonly IMenuHamburgerSERVICE menuHamburgerSERVICE;

        public CrudMenuController(IMenuSERVICE menuSERVICE, IHamburgerSERVICE hamburgerSERVICE, IByProductSERVICE byProductService, IMenuByProductSERVICE menuByProductService, IMenuHamburgerSERVICE menuHamburgerSERVICE)
        {
            this.menuSERVICE = menuSERVICE;
            this.hamburgerSERVICE = hamburgerSERVICE;
            this.byProductService = byProductService;
            this.menuByProductService = menuByProductService;
            this.menuHamburgerSERVICE = menuHamburgerSERVICE;
        }

        public async Task<IActionResult> Index()
        {
            ListMenuVM vm = new ListMenuVM();
            var menu = await menuSERVICE.GetAllAsync();
            var menuByProduct = await menuByProductService.GetAllAsync();
            var menuBurger = await menuHamburgerSERVICE.GetAllAsync();
            var byProduct = await byProductService.GetAllAsync();
            var burger = await hamburgerSERVICE.GetAllAsync();
            vm.Menus = menu;
            vm.MenuByProducts = menuByProduct;
            vm.MenuHamburgers = menuBurger;
            vm.ByProducts = byProduct;
            vm.Hamburgers = burger;



            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateUpdateMenuVM vm = new CreateUpdateMenuVM();

            var burgers = await hamburgerSERVICE.GetAllAsync();
            var byProductsDrinks = await byProductService.GetWhereAsync(x => x.ByProductType == ByProductType.Drink);
            var byProductsFries = await byProductService.GetWhereAsync(x => x.ByProductType == ByProductType.Fries);
            var byProductsSauces = await byProductService.GetWhereAsync(x => x.ByProductType == ByProductType.Sauces);

            vm.Hamburgers = burgers;
            vm.ByProductsDrinks = byProductsDrinks;
            vm.ByProductsSauces = byProductsSauces;
            vm.ByProductsFries = byProductsFries;

            ViewBag.Title = "Create";
            ViewBag.baslik = "Ekle";
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateMenuVM vm, int selectedHamburger, int selectedDrink, int selectedFry, int selectedSauce1, int selectedSauce2)
        {
            Menu menu = new Menu() { Name = vm.Name, Price = vm.Price, Description = vm.Description };
            menuSERVICE.Add(menu);

            menu.MenuHamburgers = new List<MenuHamburger>();
            menu.MenuHamburgers.Add(new MenuHamburger() { HamburgerId = selectedHamburger, MenuId = menu.Id });

            List<MenuByProduct> menuByProducts = new List<MenuByProduct>();
            menuByProducts.Add(new MenuByProduct() { ByProductId = selectedDrink, MenuId = menu.Id });
            menuByProducts.Add(new MenuByProduct() { ByProductId = selectedFry, MenuId = menu.Id });
            menuByProducts.Add(new MenuByProduct() { ByProductId = selectedSauce1, MenuId = menu.Id });
            menuByProducts.Add(new MenuByProduct() { ByProductId = selectedSauce2, MenuId = menu.Id });

            menuByProductService.Create(menuByProducts);

            return RedirectToAction("Index", "CrudMenu");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await menuSERVICE.GetByIdAsync(id);
            CreateUpdateMenuVM vm = new CreateUpdateMenuVM() { Id = id, Name = result.Name, Description = result.Description, Price = result.Price };

            var burgers = await hamburgerSERVICE.GetAllAsync();
            var byProductsDrinks = await byProductService.GetWhereAsync(x => x.ByProductType == ByProductType.Drink);
            var byProductsFries = await byProductService.GetWhereAsync(x => x.ByProductType == ByProductType.Fries);
            var byProductsSauces = await byProductService.GetWhereAsync(x => x.ByProductType == ByProductType.Sauces);

            vm.Hamburgers = burgers;
            vm.ByProductsDrinks = byProductsDrinks;
            vm.ByProductsSauces = byProductsSauces;
            vm.ByProductsFries = byProductsFries;
            var menuHamburger = menuHamburgerSERVICE.GetByMenuId(id).FirstOrDefault();
            var menuByProductDrink = byProductService.JoinedGetWhereByMenuIdProductTypeFirst(id, ByProductType.Drink);
            var menuByProductFry = byProductService.JoinedGetWhereByMenuIdProductTypeFirst(id, ByProductType.Fries);
            var menuByProductSauce1 = byProductService.JoinedGetWhereByMenuIdProductTypeFirst(id, ByProductType.Sauces);
            var menuByProductSauce2 = byProductService.JoinedGetWhereByMenuIdProductTypeLast(id, ByProductType.Sauces);
            vm.selectedHamburger = menuHamburger.HamburgerId;
            vm.selectedDrink = menuByProductDrink.Id;
            vm.selectedFry = menuByProductFry.Id;
            vm.selectedSauce1 = menuByProductSauce1.Id;
            vm.selectedSauce2 = menuByProductSauce2.Id;


            ViewBag.Title = "Update";
            ViewBag.baslik = "Güncelle";
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateUpdateMenuVM vm, int selectedHamburger, int selectedDrink, int selectedFry, int selectedSauce1, int selectedSauce2)
        {
            Menu menu = await menuSERVICE.GetByIdAsync(vm.Id);
            menu.Name = vm.Name;
            menu.Price = vm.Price;
            menu.Description = vm.Description;
            menuSERVICE.Update(menu);

            var burger = menuHamburgerSERVICE.GetByMenuId(vm.Id);
            var byProducts = await menuByProductService.GetWhereByProduct(x => x.MenuId == vm.Id);

            menuHamburgerSERVICE.Delete(burger);
            menuByProductService.Delete(byProducts);

            menu.MenuHamburgers = new List<MenuHamburger>();
            menu.MenuHamburgers.Add(new MenuHamburger() { HamburgerId = selectedHamburger, MenuId = menu.Id });

            List<MenuByProduct> menuByProducts = new List<MenuByProduct>();
            menuByProducts.Add(new MenuByProduct() { ByProductId = selectedDrink, MenuId = menu.Id });
            menuByProducts.Add(new MenuByProduct() { ByProductId = selectedFry, MenuId = menu.Id });
            menuByProducts.Add(new MenuByProduct() { ByProductId = selectedSauce1, MenuId = menu.Id });
            menuByProducts.Add(new MenuByProduct() { ByProductId = selectedSauce2, MenuId = menu.Id });

            menuByProductService.Create(menuByProducts);


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
