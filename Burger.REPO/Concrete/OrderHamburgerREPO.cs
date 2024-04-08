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
    public class OrderHamburgerREPO : BaseREPO<OrderHamburger>, IOrderHamburgerREPO
    {
        private readonly BurgerDbContext _dbContext;

        public OrderHamburgerREPO(BurgerDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public async Task<int> Create(IEnumerable<OrderHamburger> entities)
        {
            await _dbContext.OrderHamburgers.AddRangeAsync(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public int Delete(IEnumerable<OrderHamburger> entities)
        {
            _dbContext.OrderHamburgers.RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<OrderHamburger> GetByBurgerId(int id)
        {
            return _dbContext.OrderHamburgers.Where(x=>x.HamburgerId==id).ToList();
        }

        public IEnumerable<OrderHamburger> GetByOrderId(int id)
        {
            return _dbContext.OrderHamburgers.Where(x => x.OrderId == id).ToList();
        }

        public int Update(IEnumerable<OrderHamburger> entities)
        {
            _dbContext.OrderHamburgers.UpdateRange(entities);
            return _dbContext.SaveChanges();
        }
    }
}
