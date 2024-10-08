﻿using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class MenuByProduct : BaseEntity
    {
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }

        public int ByProductId { get; set; }
        public virtual ByProduct ByProduct { get; set; }

    }
}
