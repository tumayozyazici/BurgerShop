using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.REPO.Contexts;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Concrete
{
    public class ByProductREPO : BaseREPO<ByProduct>, IByProductREPO
    {
        private readonly BurgerDbContext dbContext;
        public ByProductREPO(BurgerDbContext db) : base(db)
        {
            this.dbContext = db;
        }

        public List<ByProduct> JoinedGetWhereByMenuIdProductType(int id, ByProductType type)
        {

            return dbContext.ByProducts.Join(dbContext.MenuByProducts, x => x.Id,  y => y.ByProductId,  (x, y) => new { ByProduct = x, MenuByProduct = y })
                                       .Join(dbContext.Menus,  xy => xy.MenuByProduct.MenuId,  z => z.Id, (xy, z) => new { ByProductMenu = xy, Menu = z })
                                       .Where(a => a.Menu.Id == id && a.ByProductMenu.ByProduct.ByProductType == type)
                                       .Select(a => a.ByProductMenu.ByProduct)
                                       .ToList();
        }
    }
}
