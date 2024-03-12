using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class OrderMenu : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

    }
}
