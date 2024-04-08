using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.SERVICE.Services.ShoppingCartService;
using Burger.WEBUI.Models;
using Burger.WEBUI.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IShoppingCartSERVICE _shoppingCartSERVICE;

        public ShoppingCartViewComponent(IShoppingCartSERVICE shoppingCartSERVICE)
        {
            _shoppingCartSERVICE = shoppingCartSERVICE;
        }

        public IViewComponentResult Invoke()
        {
            var currentUserShoppingCart = _shoppingCartSERVICE.GetCurrentUserShoppingcart().GetAwaiter().GetResult();
            var model = new ShoppingCartVM
            {
                TotalPrice = currentUserShoppingCart.TotalPrice,
                CartItems = new List<CartItem>()
            };

            model.CartItems.AddRange(currentUserShoppingCart.Menus.Select(menu => new CartItem()
            {
                Id = menu.MenuId,
                Name = menu.Menu.Name,
                Quantity = menu.Quantity,
                Photo = menu.Menu.Photo,
                Price = menu.Menu.Price,
                OrderType = OrderItems.Menu
            }));

            model.CartItems.AddRange(currentUserShoppingCart.Hamburgers.Select(burgers => new CartItem()
            {
                Id = burgers.HamburgerId,
                Name = burgers.Hamburger.Name,
                Quantity = burgers.Quantity,
                Photo = burgers.Hamburger.Photo,
                Price = burgers.Hamburger.Price,
                OrderType = OrderItems.Hamburger
            }));

            model.CartItems.AddRange(currentUserShoppingCart.Extras.Select(extra => new CartItem()
            {
                Id = extra.ExtraId,
                Name = extra.Extra.Name,
                Quantity = extra.Quantity,
                Price = extra.Extra.Price,
                OrderType = OrderItems.Extra
            }));

            model.CartItems.AddRange(currentUserShoppingCart.ByProducts.Select(product => new CartItem()
            {
                Id = product.ByProductId,
                Name = product.ByProduct.Name,
                Quantity = product.Quantity,
                Photo = product.ByProduct.Photo,
                Price = product.ByProduct.Price,
                OrderType = OrderItems.ByProduct
            }));

            return View(model);
        }
    }
}
