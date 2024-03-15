using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.ByProductService
{
    public interface IByProductSERVICE
    {
        int Add(ByProduct entity);
        int Update(ByProduct entity);
        int Delete(ByProduct entity);

        Task<List<ByProduct>> GetAllAsync();
        Task<ByProduct> GetByIdAsync(int id);

        Task<List<ByProduct>> GetWhereAsync(Expression<Func<ByProduct, bool>> expression);

        ByProduct JoinedGetWhereByMenuIdProductTypeFirst(int id, ByProductType type);
        ByProduct JoinedGetWhereByMenuIdProductTypeLast(int id, ByProductType type);
    }
}
