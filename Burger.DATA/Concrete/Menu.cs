using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class Menu: BaseEntity
    {

        public string Name { get; set; }

        public double Price { get; set; }

        public string? Photo { get; set; }

        public string? Description { get; set; }


        //Nav
        public virtual ICollection<OrderMenu> OrderMenus { get; set; }
        public virtual ICollection<MenuByProduct> MenuByProducts { get; set; }
    }
}
