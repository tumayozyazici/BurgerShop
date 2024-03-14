using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.OrderMenuService
{
    public interface IOrderMenuSERVICE
    {
        int Create(IEnumerable<OrderMenu> entities);
        int Update(IEnumerable<OrderMenu> entities);
        int Delete(IEnumerable<OrderMenu> entities);
        IEnumerable<OrderMenu> GetByOrderId(int id);
        IEnumerable<OrderMenu> GetByMenuId(int id);
    }
}
