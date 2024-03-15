using Burger.DATA.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Burger.WEBUI.Areas.Admin.Models.VMs
{
    public class CreateUpdateMenuVM
    {
        public int Id { get; set; }
        [DisplayName("Menü Adı")]
        public string Name { get; set; }

        [DisplayName("Fiyatı")]
        public double Price { get; set; }

        public string? Photo { get; set; }

        [DisplayName("Açıklama")]
        public string? Description { get; set; }


        public List<ByProduct> ByProductsDrinks { get; set; }
        public List<ByProduct> ByProductsFries { get; set; }
        public List<ByProduct> ByProductsSauces { get; set; }




        public List<MenuByProduct> MenuByProducts { get; set; }


        public List<Hamburger> Hamburgers { get; set; }

        public List<MenuHamburger> MenuHamburgers { get; set; }

        public int selectedHamburger { get; set; }

        public int selectedDrink { get; set; }
        public int selectedFry { get; set; }
        public int selectedSauce1 { get; set; }
        public int selectedSauce2 { get; set; }

    }
}
