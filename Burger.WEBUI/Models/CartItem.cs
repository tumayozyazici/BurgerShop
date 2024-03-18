using Burger.DATA.Concrete;
using Burger.DATA.Enums;

namespace Burger.WEBUI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }

        public double Price { get; set; }
        public OrderItems OrderType { get; set; }
    }
}
