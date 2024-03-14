using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.OrderByProductService
{
    public interface IOrderByProductSERVICE
    {
        int Create(IEnumerable<OrderByProduct> entities);
        int Update(IEnumerable<OrderByProduct> entities);
        int Delete(IEnumerable<OrderByProduct> entities);
        IEnumerable<OrderByProduct> GetByOrderId(int id);
        IEnumerable<OrderByProduct> GetByByProductId(int id);
    }
}
