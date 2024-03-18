using Burger.DATA.Enums;
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
        public OrderItems OrderType { get; set; } = OrderItems.Menu;


        //Nav
        public ICollection<OrderMenu>? OrderMenus { get; set; }
        public ICollection<MenuByProduct> MenuByProducts { get; set; }
        public ICollection<MenuHamburger> MenuHamburgers { get; set; }
        public ICollection<ShoppingCartMenu> ShoppingCartMenus { get; set; }
    }
}
