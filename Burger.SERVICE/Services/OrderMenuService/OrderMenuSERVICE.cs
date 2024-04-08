using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.OrderMenuService
{
    public class OrderMenuSERVICE : IOrderMenuSERVICE
    {
        private readonly IOrderMenuREPO _orderMenuREPO;

        public OrderMenuSERVICE(IOrderMenuREPO orderMenuREPO)
        {
            _orderMenuREPO = orderMenuREPO;
        }

        public async Task<int> Create(IEnumerable<OrderMenu> entities)
        {
            return await _orderMenuREPO.Create(entities);
        }

        public int Delete(IEnumerable<OrderMenu> entities)
        {
            return _orderMenuREPO.Delete(entities);
        }

        public IEnumerable<OrderMenu> GetByMenuId(int id)
        {
            return _orderMenuREPO.GetByMenuId(id);
        }

        public IEnumerable<OrderMenu> GetByOrderId(int id)
        {
            return _orderMenuREPO.GetByOrderId(id);
        }

        public int Update(IEnumerable<OrderMenu> entities)
        {
            return _orderMenuREPO.Update(entities);
        }
    }
}
