using Burger.DATA.Concrete;
using Burger.SERVICE.Services.CartService;
using Burger.SERVICE.Services.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICartSERVICE _cartService;
        private readonly IMenuSERVICE _menuService;

        public ShoppingCartController(ICartSERVICE cartService, IMenuSERVICE menuService)
        {
            _cartService = cartService;
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int menuId)
        {
            Cart cart = new Cart();
            Menu menu = await _menuService.GetByIdAsync(menuId);

            List<Menu> menuList = new List<Menu>();
            menuList.Add(menu);

            if (menu != null)
            {
                cart.Menus = menuList;
            }
            _cartService.Add(cart);
            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
