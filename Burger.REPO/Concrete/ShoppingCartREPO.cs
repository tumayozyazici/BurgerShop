using Burger.DATA.Concrete;
using Burger.REPO.Contexts;
using Burger.REPO.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Concrete
{
    public class ShoppingCartREPO : BaseREPO<ShoppingCart>, IShoppingCartREPO
    {
        private readonly BurgerDbContext _db;

        public ShoppingCartREPO(BurgerDbContext db) : base(db)
        {
            _db = db;
        }


        public async Task<ShoppingCart?> GetUserShoppingCart(Guid userId)
        {
            return await _db.ShoppingCarts
                .Include(sc => sc.Menus)
                .ThenInclude(menu => menu.Menu)
                .Include(sc => sc.ByProducts)
                 .ThenInclude(menu => menu.ByProduct)
                .Include(sc => sc.Extras)
                 .ThenInclude(menu => menu.Extra)
                .Include(sc => sc.Hamburgers)
                 .ThenInclude(menu => menu.Hamburger)
                .FirstOrDefaultAsync(sc => sc.UserId == userId);
        }
    }
}
