using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.MenuByProductService
{
    public class MenuByProductSERVICE : IMenuByProductSERVICE
    {
        private readonly IMenuByProductREPO _menuByProductREPO;

        public MenuByProductSERVICE(IMenuByProductREPO menuByProductREPO)
        {
            _menuByProductREPO = menuByProductREPO;
        }

        public int Create(IEnumerable<MenuByProduct> entities)
        {
            return _menuByProductREPO.Create(entities);
        }

        public int Delete(IEnumerable<MenuByProduct> entities)
        {
            return _menuByProductREPO.Delete(entities);
        }

        public Task<List<MenuByProduct>> GetAllAsync()
        {
            return _menuByProductREPO.GetAllAsync();
        }

        public IEnumerable<MenuByProduct> GetByByProductId(int id)
        {
            return _menuByProductREPO.GetByByProductId(id);
        }

        public IEnumerable<MenuByProduct> GetByMenuId(int id)
        {
            return _menuByProductREPO.GetByMenuId(id);
        }

        public async Task<IEnumerable<MenuByProduct>> GetWhereByProduct(Expression<Func<MenuByProduct, bool>> expression)
        {
            return await _menuByProductREPO.GetWhereAsync(expression);
        }

        public int Update(IEnumerable<MenuByProduct> entities)
        {
            return _menuByProductREPO.Update(entities);
        }

    }
}
