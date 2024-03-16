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
    public class OrderExtraREPO : BaseREPO<OrderExtra> ,IOrderExtraREPO
    {
        private readonly BurgerDbContext _dbContext;

        public OrderExtraREPO(BurgerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(IEnumerable<OrderExtra> entities)
        {
            _dbContext.OrderExtras.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public int Delete(IEnumerable<OrderExtra> entities)
        {
            _dbContext.OrderExtras.RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<OrderExtra> GetByExtraId(int id)
        {
            return _dbContext.OrderExtras.Where(x => x.ExtraId == id).ToList();
        }

        public IEnumerable<OrderExtra> GetByOrderId(int id)
        {
            return _dbContext.OrderExtras.Where(x => x.OrderId == id).ToList();
        }

        public int Update(IEnumerable<OrderExtra> entities)
        {
            _dbContext.OrderExtras.UpdateRange(entities);
            return _dbContext.SaveChanges();
        }
    }
}
