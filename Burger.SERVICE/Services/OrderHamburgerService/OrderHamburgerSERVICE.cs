using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.OrderHamburgerService
{
    public class OrderHamburgerSERVICE : IOrderHamburgerSERVICE
    {
        private readonly IOrderHamburgerREPO _orderHamburgerREPO;

        public OrderHamburgerSERVICE(IOrderHamburgerREPO orderHamburgerREPO)
        {
            _orderHamburgerREPO = orderHamburgerREPO;
        }

        public int Create(IEnumerable<OrderHamburger> entities)
        {
            return _orderHamburgerREPO.Create(entities);
        }

        public int Delete(IEnumerable<OrderHamburger> entities)
        {
            return _orderHamburgerREPO.Delete(entities);
        }

        public IEnumerable<OrderHamburger> GetByBurgerId(int id)
        {
            return _orderHamburgerREPO.GetByBurgerId(id);
        }

        public IEnumerable<OrderHamburger> GetByOrderId(int id)
        {
            return _orderHamburgerREPO.GetByOrderId(id);
        }

        public int Update(IEnumerable<OrderHamburger> entities)
        {
            return _orderHamburgerREPO.Update(entities);
        }
    }
}
