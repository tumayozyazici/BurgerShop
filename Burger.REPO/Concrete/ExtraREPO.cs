﻿using Burger.DATA.Concrete;
using Burger.REPO.Contexts;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Concrete
{
    public class ExtraREPO : BaseREPO<Extra>, IExtraREPO
    {
        public ExtraREPO(BurgerDbContext db) : base(db)
        {
        }
    }
}
