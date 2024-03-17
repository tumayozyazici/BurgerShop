using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class ShoppingCart : BaseEntity
    {
        public Guid UserId { get; set; }

        public double TotalPrice { get; set; }

        public virtual ICollection<ShoppingCartMenu> Menus { get; set; } = new List<ShoppingCartMenu>();
        public virtual ICollection<ShoppingCartHamburger> Hamburgers { get; set; } = new List<ShoppingCartHamburger>();
        public virtual ICollection<ShoppingCartExtra> Extras { get; set; } = new List<ShoppingCartExtra>();
        public virtual ICollection<ShoppingCartByProduct> ByProducts { get; set; } = new List<ShoppingCartByProduct>();

    }

    public class ShoppingCartMenu : BaseEntity
    {
        public int MenuId { get; set; }

        public Menu Menu { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }

    public class ShoppingCartHamburger : BaseEntity
    {
        public int HamburgerId { get; set; }

        public Hamburger Hamburger { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }

    public class ShoppingCartExtra : BaseEntity
    {
        public int ExtraId { get; set; }

        public Extra Extra { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }

    public class ShoppingCartByProduct : BaseEntity
    {
        public int ByProductId { get; set; }
        public ByProduct ByProduct { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}
