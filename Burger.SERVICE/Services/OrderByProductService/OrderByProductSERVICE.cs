using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.OrderByProductService
{
    public class OrderByProductSERVICE : IOrderByProductSERVICE
    {
        private readonly IOrderByProductREPO _orderByProductREPO;

        public OrderByProductSERVICE(IOrderByProductREPO orderByProductREPO)
        {
            _orderByProductREPO = orderByProductREPO;
        }

        public int Create(IEnumerable<OrderByProduct> entities)
        {
            return _orderByProductREPO.Create(entities);
        }

        public int Delete(IEnumerable<OrderByProduct> entities)
        {
            return _orderByProductREPO.Delete(entities);
        }

        public IEnumerable<OrderByProduct> GetByByProductId(int id)
        {
            return _orderByProductREPO.GetByByProductId(id);
        }

        public IEnumerable<OrderByProduct> GetByOrderId(int id)
        {
            return _orderByProductREPO.GetByOrderId(id);
        }

        public int Update(IEnumerable<OrderByProduct> entities)
        {
            return _orderByProductREPO.Update(entities);
        }
    }
}
