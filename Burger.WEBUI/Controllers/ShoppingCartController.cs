using Burger.DATA.Concrete;
using Burger.SERVICE.Services.CartService;
using Burger.SERVICE.Services.MenuService;
using Burger.SERVICE.Services.ShoppingCartService;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartSERVICE _cartService;
        private readonly IMenuSERVICE _menuService;

        public ShoppingCartController(IShoppingCartSERVICE cartService, IMenuSERVICE menuService, IHttpContextAccessor httpContextAccessor)
        {
            _cartService = cartService;
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddMenuToCart(int id, int quantity)
        {
            var shoppingCart = await _cartService.AddMenu(id, quantity);


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddHamburgerToCart(int id, int quantity)
        {
            var shoppingCart = await _cartService.AddHamburger(id, quantity);


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddExtraToCart(int id, int quantity)
        {
            var shoppingCart = await _cartService.AddExtra(id, quantity);


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddByProductToCart(int id, int quantity)
        {
            var shoppingCart = await _cartService.AddByProduct(id, quantity);


            return RedirectToAction("Index", "Home");
        }
    }
}
