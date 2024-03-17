using Burger.DATA.Concrete;

namespace Burger.WEBUI.Models
{
    public class CartItem
    {
        public List<Hamburger> Hamburgers { get; set; }
        public List<ByProduct> ByProducts { get; set; }
        public List<Extra> Extras { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
