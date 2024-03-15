using Burger.DATA.Concrete;

namespace Burger.WEBUI.Areas.Admin.Models.VMs
{
    public class ListMenuVM
    {
        public List<ByProduct> ByProducts { get; set; }
        public List<MenuByProduct> MenuByProducts { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Hamburger> Hamburgers { get; set; }
        public List<MenuHamburger> MenuHamburgers { get; set; }
    }
}
