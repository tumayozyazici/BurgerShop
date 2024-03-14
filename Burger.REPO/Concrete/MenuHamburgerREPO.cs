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
    public class MenuHamburgerREPO : BaseREPO<MenuHamburger>, IMenuHamburgerREPO
    {
        private readonly BurgerDbContext _dbContext;

        public MenuHamburgerREPO(BurgerDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public int Create(IEnumerable<MenuHamburger> entities)
        {
            _dbContext.MenuHamburgers.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public int Delete(IEnumerable<MenuHamburger> entities)
        {
            _dbContext.MenuHamburgers.RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<MenuHamburger> GetByBurgerId(int burgerId)
        {
            return _dbContext.MenuHamburgers.Where(x => x.HamburgerId == burgerId).ToList();
        }

        public IEnumerable<MenuHamburger> GetByMenuId(int menuId)
        {
            return _dbContext.MenuHamburgers.Where(x => x.MenuId == menuId).ToList();
        }

        public int Update(IEnumerable<MenuHamburger> entities)
        {
            _dbContext.MenuHamburgers.UpdateRange(entities);
            return _dbContext.SaveChanges();
        }
    }
}
