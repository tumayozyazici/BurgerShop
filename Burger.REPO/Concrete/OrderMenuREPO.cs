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
    public class OrderMenuREPO : BaseREPO<OrderMenu>, IOrderMenuREPO
    {
        private readonly BurgerDbContext _dbContext;
        public OrderMenuREPO(BurgerDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public int Create(IEnumerable<OrderMenu> entities)
        {
            _dbContext.OrderMenus.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public int Delete(IEnumerable<OrderMenu> entities)
        {
            _dbContext.OrderMenus.RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<OrderMenu> GetByMenuId(int id)
        {
            return _dbContext.OrderMenus.Where(x => x.MenuId == id).ToList();
        }

        public IEnumerable<OrderMenu> GetByOrderId(int id)
        {
            return _dbContext.OrderMenus.Where(x => x.OrderId == id).ToList();
        }

        public int Update(IEnumerable<OrderMenu> entities)
        {
            _dbContext.OrderMenus.UpdateRange(entities);
            return _dbContext.SaveChanges();
        }
    }
}
