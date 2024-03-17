using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using Burger.SERVICE.Services.ByProductService;
using Burger.SERVICE.Services.ExtraService;
using Burger.SERVICE.Services.HamburgerExtraService;
using Burger.SERVICE.Services.HamburgerService;
using Burger.SERVICE.Services.MenuService;
using Burger.WEBUI.Models;
using Burger.WEBUI.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Burger.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        public static CreateUserVm _user;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHamburgerSERVICE _hamburgerService;
        private readonly IByProductSERVICE _byProductService;
        private readonly IExtraSERVICE _extraService;
        private readonly IMenuSERVICE _menuService;

        public HomeController(ILogger<HomeController> logger, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IHamburgerSERVICE hamburgerService, IByProductSERVICE byProductService, IExtraSERVICE extraService, IMenuSERVICE menuService)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _hamburgerService = hamburgerService;
            _byProductService = byProductService;
            _extraService = extraService;
            _menuService = menuService;
        }

        public async Task<IActionResult> Index()
        {
            ListProductsVM vm = new ListProductsVM();
            var burger = await _hamburgerService.GetAllAsync();
            var byProducts = await _byProductService.GetAllAsync();
            var extras = await _extraService.GetAllAsync();
            var menus = await _menuService.GetAllAsync();
            vm.Menus = menus;
            vm.ByProducts = byProducts;
            vm.Hamburgers = burger;
            vm.Extras = extras;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserVm vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(vm.Email);

                if (user == null)
                {
                    Random rnd = new Random();
                    int confirmationCode = rnd.Next(10000, 99999);

                    HelperClass.Helper.SendMail(user, vm, confirmationCode);

                    _user = vm;
                    TempData["confirmationCode"] = confirmationCode;
                    return RedirectToAction("Confirmation", "Home");
                }
                else
                {
                    ViewBag.rejection = "Bu E-mail'de bir kullanıcı mevcut.";
                    return View(vm);
                }
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Confirmation(ConfirmationCodeVm vm)
        {
            if (vm.ConfirmationCode == TempData["confirmationCode"].ToString())
            {
                var user = new AppUser() { UserName = _user.Email, FirstName = _user.FirstName, LastName = _user.LastName, Email = _user.Email, Address = _user.Address };
                var result = await _userManager.CreateAsync(user, _user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Code + " - " + item.Description);
                }
                return View();
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVm vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Giriş Başarısız");
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
