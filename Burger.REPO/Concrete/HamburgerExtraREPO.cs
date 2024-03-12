using Burger.DATA.Concrete;
using Burger.REPO.Contexts;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Concrete
{
    public class HamburgerExtraREPO : BaseREPO<HamburgerExtra>, IHamburgerExtraREPO
    {
        public HamburgerExtraREPO(BurgerDbContext db) : base(db)
        {
        }
    }
}
