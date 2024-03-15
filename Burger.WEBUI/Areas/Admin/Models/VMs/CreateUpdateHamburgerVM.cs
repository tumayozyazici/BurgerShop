using Burger.DATA.Concrete;
using System.ComponentModel;

namespace Burger.WEBUI.Areas.Admin.Models.VMs
{
    public class CreateUpdateHamburgerVM
    {
        public int Id { get; set; }
        [DisplayName("Burger Adı")]
        public string Name { get; set; }

        [DisplayName("Fiyatı")]
        public double Price { get; set; }

        public string? Photo { get; set; }

        [DisplayName("Açıklama")]
        public string? Description { get; set; }

        public List<Extra> Extras { get; set; }

        public List<HamburgerExtra> HamburgerExtras { get; set; }
        
    }
}
