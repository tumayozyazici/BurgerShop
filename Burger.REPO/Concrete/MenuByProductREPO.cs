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
    public class MenuByProductREPO : BaseREPO<MenuByProduct>, IMenuByProductREPO
    {
        private readonly BurgerDbContext _dbContext;

        public MenuByProductREPO(BurgerDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public int Create(IEnumerable<MenuByProduct> entities)
        {
            _dbContext.MenuByProducts.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public int Delete(IEnumerable<MenuByProduct> entities)
        {
            _dbContext.MenuByProducts.RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<MenuByProduct> GetByByProductId(int productId)
        {
            return _dbContext.MenuByProducts.Where(x => x.ByProductId == productId).ToList();
        }

        public IEnumerable<MenuByProduct> GetByMenuId(int menuId)
        {
            return _dbContext.MenuByProducts.Where(x => x.MenuId == menuId).ToList();
        }

        public int Update(IEnumerable<MenuByProduct> entities)
        {
            _dbContext.MenuByProducts.UpdateRange(entities);
            return _dbContext.SaveChanges();
        }
    }
}
