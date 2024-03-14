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
    public class OrderByProductREPO : BaseREPO<OrderByProduct>, IOrderByProductREPO
    {
        private readonly BurgerDbContext _dbContext;

        public OrderByProductREPO(BurgerDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public int Create(IEnumerable<OrderByProduct> entities)
        {
            _dbContext.OrderByProducts.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public int Delete(IEnumerable<OrderByProduct> entities)
        {
            _dbContext.OrderByProducts.RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<OrderByProduct> GetByByProductId(int id)
        {
            return _dbContext.OrderByProducts.Where(x=>x.ByProductId==id).ToList();
        }

        public IEnumerable<OrderByProduct> GetByOrderId(int id)
        {
            return _dbContext.OrderByProducts.Where(x => x.OrderId == id).ToList();
        }

        public int Update(IEnumerable<OrderByProduct> entities)
        {
            _dbContext.OrderByProducts.UpdateRange(entities);
            return _dbContext.SaveChanges();
        }
    }
}
