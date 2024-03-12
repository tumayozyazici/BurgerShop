using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class HamburgerExtra : BaseEntity
    {
        public int HamburgerId { get; set; }
        public Hamburger Hamburger { get; set; }

        public int ExtraId { get; set; }
        public Extra Extra { get; set; }

    }
}
