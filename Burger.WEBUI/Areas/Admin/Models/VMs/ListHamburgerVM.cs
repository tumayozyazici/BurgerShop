using Burger.DATA.Concrete;

namespace Burger.WEBUI.Areas.Admin.Models.VMs
{
    public class ListHamburgerVM
    {
        public List<Hamburger> Hamburgers { get; set; }

        public List<Extra> Extras { get; set; }

        public List<HamburgerExtra> HamburgerExtras { get; set; }
    }
}
