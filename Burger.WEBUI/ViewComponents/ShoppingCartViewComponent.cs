using Burger.DATA.Concrete;
using Burger.WEBUI.Models;
using Burger.WEBUI.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cartItems = new List<CartItem>();

            //CartItems Bir şekilde dolacak burada!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1111


            var model = new ShoppingCartVM() { CartItems = cartItems, TotalPrice = CalculateTotalPrice(cartItems) };

            return View(model);
        }
        private double CalculateTotalPrice(List<CartItem> cartItems)
        {
            double totalPrice = 0;

            foreach (var item in cartItems)
            {
                foreach (Menu menu in item.Menus)
                {
                    totalPrice += menu.Price;
                }
                foreach (Hamburger burger in item.Hamburgers)
                {
                    totalPrice += burger.Price;
                }
                foreach (ByProduct byProduct in item.ByProducts)
                {
                    totalPrice += byProduct.Price;
                }
                foreach (Extra extra in item.Extras)
                {
                    totalPrice += extra.Price;
                }
            }
            return totalPrice;
        }
    }
}
