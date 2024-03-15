using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.MenuByProductService
{
    public interface IMenuByProductSERVICE
    {
        int Create(IEnumerable<MenuByProduct> entities);
        int Update(IEnumerable<MenuByProduct> entities);
        int Delete(IEnumerable<MenuByProduct> entities);
        IEnumerable<MenuByProduct> GetByMenuId(int id);
        IEnumerable<MenuByProduct> GetByByProductId(int id);

        Task<List<MenuByProduct>> GetAllAsync();
        Task<IEnumerable<MenuByProduct>> GetWhereByProduct(Expression<Func<MenuByProduct, bool>> expression);
    }
}
