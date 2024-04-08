using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.OrderExtraService
{
    public class OrderExtraSERVICE : IOrderExtraSERVICE
    {
        private readonly IOrderExtraREPO _orderExtraREPO;

        public OrderExtraSERVICE(IOrderExtraREPO orderExtraREPO)
        {
            _orderExtraREPO = orderExtraREPO;
        }

        public async Task<int> Create(IEnumerable<OrderExtra> entities)
        {
            return await _orderExtraREPO.Create(entities);
        }

        public int Delete(IEnumerable<OrderExtra> entities)
        {
            return _orderExtraREPO.Delete(entities);
        }

        public IEnumerable<OrderExtra> GetByExtraId(int id)
        {
            return _orderExtraREPO.GetByExtraId(id);
        }

        public IEnumerable<OrderExtra> GetByOrderId(int id)
        {
            return _orderExtraREPO.GetByOrderId(id);
        }

        public int Update(IEnumerable<OrderExtra> entities)
        {
            return _orderExtraREPO.Update(entities);
        }
    }
}
