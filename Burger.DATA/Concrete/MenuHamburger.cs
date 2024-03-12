﻿using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class MenuHamburger : BaseEntity
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int HamburgerId { get; set; }
        public Hamburger Hamburger { get; set; }


    }
}