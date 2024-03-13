using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class Hamburger : BaseEntity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string? Photo { get; set; }

        public string? Description { get; set; }


        //Nav
        public virtual ICollection<HamburgerExtra>? HamburgerExtras { get; set; }
        public virtual ICollection<OrderHamburger> OrderHamburgers { get; set; }
        public virtual ICollection<MenuHamburger> MenuHamburgers { get; set; }
    }
}
