using Burger.DATA.Concrete;

namespace Burger.WEBUI.Models.VMs
{
    public class ShoppingCartVM
    {
        public List<CartItem> CartItems { get; set; }
        public double TotalPrice { get; set; }
       
    }
}
