using Burger.DATA.Concrete;
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
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(ILogger<HomeController> logger, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public static CreateUserVm _user;
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserVm vm)
        {
            var user = await _userManager.FindByEmailAsync(vm.Email);

            if (user == null)
            {
                
                Random rnd = new Random();
                int confirmationCode = rnd.Next(10000, 99999);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("burgershop12@outlook.com", "BurgerShop");
                mail.To.Add(vm.Email);
                mail.Subject = "BurgerShop Doğrulama Kodu";
                mail.IsBodyHtml = true;
                mail.Body = "BurgerShop'a hoşgeldiniz. İşte doğrulama kodun: " + confirmationCode;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.outlook.com";
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("burgershop12@outlook.com", "Admin..1234");

                smtpClient.Send(mail);
                smtpClient.Timeout = 100;

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
        
        [HttpGet]
        public IActionResult Confirmation()
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
        public IActionResult Login()
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
