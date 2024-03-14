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
        private readonly BurgerDbContext _dbContext;

        public HamburgerExtraREPO(BurgerDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public int Create(IEnumerable<HamburgerExtra> entities)
        {
            _dbContext.HamburgerExtras.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public int Delete(IEnumerable<HamburgerExtra> entities)
        {
            _dbContext.HamburgerExtras.RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<HamburgerExtra> GetByBurgerId(int burgerId)
        {
            return _dbContext.HamburgerExtras.Where(x => x.HamburgerId == burgerId).ToList();
        }

        public int Update(IEnumerable<HamburgerExtra> entities)
        {
            _dbContext.HamburgerExtras.UpdateRange(entities);
            return _dbContext.SaveChanges();
        }
    }
}
