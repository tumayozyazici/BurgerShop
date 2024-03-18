using Burger.DATA.Enums;
using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class Extra : BaseEntity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }

        public OrderItems OrderType { get; set; } = OrderItems.Extra;

        //Nav
        public virtual ICollection<HamburgerExtra> HamburgerExtras { get; set; }
        public virtual ICollection<OrderExtra> OrderExtras { get; set; }
    }
}
