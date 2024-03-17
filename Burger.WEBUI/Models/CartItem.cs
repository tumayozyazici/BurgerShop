using Burger.DATA.Concrete;

namespace Burger.WEBUI.Models
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
    }
}
